using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Win32API
{
    public class Win32Program
    {
	public static bool IsRunning;
	public static WindowDimension WindowDim;
	
	[STAThread]
        public static void Main()
        {
            HINSTANCE instance = new HINSTANCE(Win32.GetModuleHandle(null));
            if(instance != null)
            {
                Console.WriteLine("Instance instance created");
                WndProc windowProc = new WndProc(MainCallback);
                
                WNDCLASS windowClass = new WNDCLASS();
                windowClass.Style = Win32.Cs.HorizontalRedraw | Win32.Cs.VerticalRedraw | Win32.Cs.OwnDC;
                windowClass.Instance(instance);
                windowClass.WindowProc = windowProc;
                windowClass.ClassName = "AoESharpWindowClass";
		windowClass.Cursor(Win32.LoadCursor(null, (short)Win32.Idc.Arrow));
                windowClass.Background(Win32.GetStockObject(StockObject.BlackBrush));
                
                if(Win32.RegisterClass(ref windowClass) != 0)
                {
                    Console.WriteLine("Class registered successfully");

                    HWND window = new HWND(Win32.CreateWindowEx(0, windowClass.ClassName, "Age of Empires Sharp", Win32.Ws.OverlappedWindow,
								(uint)Win32.Cw.UseDefault, (uint)Win32.Cw.UseDefault,
								(uint)Win32.Cw.UseDefault, (uint)Win32.Cw.UseDefault,
								null, null, instance, new IntPtr(0)));
		    
                    if (window != null)
                    {
			Console.WriteLine("Window created successfully");
			WindowDim = new WindowDimension(window);
			Win32.ShowWindow(window, (uint)Win32.Sw.Show);

			IsRunning = true;
			while(IsRunning)
			{
			    ProcessPendingMessages();
			}
                    }
                    else
                    {
                        Console.WriteLine("Win32 Error: {0}", Win32.GetLastError());
                    }
                }
                else
                {
                    Console.WriteLine("Win32 Error: {0}", Win32.GetLastError());
                }
            }
            else
            {
                Console.WriteLine("Win32 Error: {0}", Win32.GetLastError());
            }
        }

        public static IntPtr MainCallback(IntPtr window, uint message, uint wParam, uint lParam)
        {
	    IntPtr result = new IntPtr(0);
	    
	    Win32.Wm wmMessage = (Win32.Wm)message;
	    switch(wmMessage)
	    {
		case Win32.Wm.WindowPosChanging:
		{
		    result = Win32.DefWindowProc(window, message, wParam, lParam);
		} break;

		/*
		case Win32.Wm.SetCursor:
		{
		    Win32.SetCursor(null);
		} break;
		*/
		
		case Win32.Wm.Destroy:
		{
		    IsRunning = false;
		} break;

		case Win32.Wm.Close:
		{
		    IsRunning = false;
		} break;

		case Win32.Wm.Paint:
		{
		    HWND windowHandle = (HWND)window;
		    PAINTSTRUCT paint;
		    HDC deviceContext = new HDC(Win32.BeginPaint(windowHandle, out paint));

		    DisplayBuffer(deviceContext);
		    
		    Win32.EndPaint(windowHandle, ref paint);
		} break;
		    
		default:
		{
		    result = Win32.DefWindowProc(window, message, wParam, lParam);
		} break;
	    }
	    
            return(result);
        }

        public static void ProcessPendingMessages()
        {
	    MSG message;
	    while(true)
	    {
		bool gotMessage = false;
		gotMessage = Win32.PeekMessage(out message, null, 0, 0, (uint)Win32.Pm.Remove);
		if(!gotMessage)
		{
		    break;
		}
		else
		{
		    switch(message.Message)
		    {
			default:
			    break;
		    }

		    Win32.TranslateMessage(ref message);
		    Win32.DispatchMessage(ref message);
		}
	    }
        }

	public static void DisplayBuffer(HDC deviceContext)
	{
	    WindowDim.Update();
	}
    }

    public class WindowDimension
    {
	public HWND Window;
	public int Width;
	public int Height;
	
	public WindowDimension(HWND window)
	{
	    Window = window;
	    Update();
	}

	public void Update()
	{
	    Debug.Assert(Window != null);
	    
	    RECT clientRect = new RECT();
	    Win32.GetClientRect((HANDLE)Window, ref clientRect);
	    this.Width = clientRect.Right - clientRect.Left;
	    this.Height = clientRect.Bottom - clientRect.Top;
	}
    }
}
