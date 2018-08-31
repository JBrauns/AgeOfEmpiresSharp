using System;
using System.Runtime.InteropServices;

namespace Win32API
{
    public class DWORD
    {
        public UInt32 Value;

        public DWORD(UInt32 value) { this.Value = value; }

        public static explicit operator DWORD(UInt32 value)
        {
            DWORD result = new DWORD(value);
            return(result);
        }

        public static DWORD operator+(DWORD result, UInt32 addend)
        {
            result.Value += addend;
            return(result);
        }

        public static DWORD operator-(DWORD result, UInt32 addend)
        {
            result.Value -= addend;
            return(result);
        }
    }
    
    public class PVOID
    {
        public IntPtr Value;

        public PVOID(IntPtr value) { this.Value = value; }
        public PVOID(Int32 value) { this.Value = new IntPtr(value); }
        public PVOID(Int64 value) { this.Value = new IntPtr(value); }

        public static explicit operator PVOID(Int32 value)
        {
            PVOID result = new PVOID(value);
            return(result);
        }

        public static explicit operator PVOID(Int64 value)
        {
            PVOID result = new PVOID(value);
            return(result);
        }

        public static PVOID operator+(PVOID result, Int32 addend)
        {
            result.Value += addend;
            return(result);
        }
    }

    public class HANDLE : PVOID
    {
        public HANDLE(IntPtr value) : base(value) {}
        public HANDLE(Int32 value) : base(value) {}
        public HANDLE(Int64 value) : base(value) {}

	public static IntPtr ValidateValue(HANDLE value)
	{
	    IntPtr result = new IntPtr(0);
	    if(value != null)
	    {
		result = value.Value;
	    }
	    return(result);
	}

        public static explicit operator HANDLE(Int32 value)
        {
            HANDLE result = new HANDLE(value);
            return(result);
        }

        public static explicit operator HANDLE(Int64 value)
        {
            HANDLE result = new HANDLE(value);
            return(result);
        }

        public static HANDLE operator+(HANDLE handle, Int32 addend)
        {
            PVOID result = (PVOID)handle + addend;
            return((HANDLE)result);
        }
    }

    public class HINSTANCE : HANDLE
    {
        public HINSTANCE(HANDLE value) : base(value.Value) {}
        public HINSTANCE(IntPtr value) : base(value) {}
        public HINSTANCE(Int32 value) : base(value) {}
        public HINSTANCE(Int64 value) : base(value) {}

        public static explicit operator HINSTANCE(Int32 value)
        {
            HINSTANCE result = new HINSTANCE(value);
            return(result);
        }

        public static explicit operator HINSTANCE(Int64 value)
        {
            HINSTANCE result = new HINSTANCE(value);
            return(result);
        }

        public static HANDLE operator+(HINSTANCE handle, Int32 addend)
        {
            HANDLE result = (HANDLE)handle + addend;
            return((HINSTANCE)result);
        }
    }

    public class HGDIOBJ : HANDLE
    {
        public HGDIOBJ(HANDLE value) : base(value.Value) {}
        public HGDIOBJ(Int32 value) : base(value) {}
        public HGDIOBJ(Int64 value) : base(value) {}

        public static explicit operator HGDIOBJ(Int32 value)
        {
            HGDIOBJ result = new HGDIOBJ(value);
            return(result);
        }

        public static explicit operator HGDIOBJ(Int64 value)
        {
            HGDIOBJ result = new HGDIOBJ(value);
            return(result);
        }

        public static HANDLE operator+(HGDIOBJ handle, Int32 addend)
        {
            HANDLE result = (HANDLE)handle + addend;
            return((HGDIOBJ)result);
        }
    }

    public class HBRUSH : HANDLE
    {
        public HBRUSH(HANDLE value) : base(value.Value) {}
        public HBRUSH(Int32 value) : base(value) {}
        public HBRUSH(Int64 value) : base(value) {}

        public static explicit operator HBRUSH(Int32 value)
        {
            HBRUSH result = new HBRUSH(value);
            return(result);
        }

        public static explicit operator HBRUSH(Int64 value)
        {
            HBRUSH result = new HBRUSH(value);
            return(result);
        }

        public static HANDLE operator+(HBRUSH handle, Int32 addend)
        {
            HANDLE result = (HANDLE)handle + addend;
            return((HBRUSH)result);
        }
    }

    public class HWND : HANDLE
    {
        public HWND(HANDLE value) : base(ValidateValue(value)) {}
        public HWND(IntPtr value) : base(value) {}
        public HWND(Int32 value) : base(value) {}
        public HWND(Int64 value) : base(value) {}
	
        public static explicit operator HWND(IntPtr value)
        {
            HWND result = new HWND(value);
            return(result);
        }
	
        public static explicit operator HWND(Int32 value)
        {
            HWND result = new HWND(value);
            return(result);
        }

        public static explicit operator HWND(Int64 value)
        {
            HWND result = new HWND(value);
            return(result);
        }

        public static HANDLE operator+(HWND handle, Int32 addend)
        {
            HANDLE result = (HANDLE)handle + addend;
            return((HWND)result);
        }
    }

    public class HDC : HANDLE
    {
        public HDC(HANDLE value) : base(value.Value) {}
        public HDC(IntPtr value) : base(value) {}
        public HDC(Int32 value) : base(value) {}
        public HDC(Int64 value) : base(value) {}

        public static explicit operator HDC(Int32 value)
        {
            HDC result = new HDC(value);
            return(result);
        }

        public static explicit operator HDC(Int64 value)
        {
            HDC result = new HDC(value);
            return(result);
        }

        public static HANDLE operator+(HDC handle, Int32 addend)
        {
            HANDLE result = (HANDLE)handle + addend;
            return((HDC)result);
        }
    }

    public class HANDLEMarshaler : ICustomMarshaler
    {
        public Object MarshalNativeToManaged(IntPtr nativeData)
        {
	    if(nativeData == null)
	    {
		nativeData = new IntPtr(0);
	    }
	    HANDLE result = new HANDLE(nativeData);
	    
            return(result);
        }

        public IntPtr MarshalManagedToNative(Object managedObject)
        {
            HANDLE result = (HANDLE)managedObject;
            return(result.Value);
        }
        
        public void CleanUpNativeData(IntPtr pNativeData)
        {
        }
        
        public void CleanUpManagedData(Object ManagedObj)
        {
        }
        
        public int GetNativeDataSize()
        {
            return(0);
        }

        public static ICustomMarshaler GetInstance(string cookie)
        {
            HANDLEMarshaler result = new HANDLEMarshaler();
            return(result);
        }
    }

    public static class Win32
    {
        [FlagsAttribute]
        public enum WsEx : ulong // Extended Window Style
        {
            AcceptFiles         = 0x00000010,
            AppWindow           = 0x00040000,
            ClientEdge          = 0x00000200,
            Composited          = 0x02000000,
            ContextHelp         = 0x00000400,
            ControlParent       = 0x00010000,
            DlgModalFrame       = 0x00000001,
            Layered             = 0x00080000,
            LayoutRtl           = 0x00400000,
            Left                = 0x00000000,
            LeftScrollBar       = 0x00004000,
            LtrReading          = 0x00000000,
            MdiChild            = 0x00000040,
            NoActivate          = 0x08000000,
            NoInheritLayout     = 0x00100000,
            NoParentNotify      = 0x00000004,
            NoRedirectionBitmap = 0x00200000,
            OverlappedWindow    = WindowEdge | ClientEdge,
            PaletteWindow       = WindowEdge | ToolWindow | Topmost,
            Right               = 0x00001000,
            RightScrollbar      = 0x00000000,
            RtlReading          = 0x00002000,
            StaticEdge          = 0x00020000,
            ToolWindow          = 0x00000080,
            Topmost             = 0x00000008,
            Transparent         = 0x00000020,
            WindowEdge          = 0x00000100
        }

        [FlagsAttribute]
        public enum Cs : uint
        {
            VerticalRedraw = (1 << 0),
            HorizontalRedraw = (1 << 1),
            DoubleClicks = (1 << 3),
            OwnDC = 0x0020,
            ClassDC = 0x0040,
            ParentDC = 0x0080,
            NoClose = 0x0200,
            SaveBits = 0x0800,
            ByteAlignClient = 0x1000,
            ByteAlignWindow = 0x2000,
            GlobalClass = 0x4000,
            DropShadow = 0x00020000
        }

        [FlagsAttribute]
        public enum Cw : uint
        {
            UseDefault = 0x80000000
        }

        [FlagsAttribute]
        public enum Sw : uint
        {
            Hide            = 0,
            ShowNormal      = 1,
            ShowMinimized   = 2,
            Maximize        = 3,
            ShowMaximized   = 3,
            ShowNoActivated = 4,
            Show            = 5,
            Minimize        = 6,
            ShowMinNoActive = 7,
            ShowNa          = 8,
            Restore         = 9,
            ShowDefault     = 10,
            ForceMinimize   = 11
        }

        [FlagsAttribute]
        public enum Ws : ulong
        {
            Border           = 0x00800000,
            Caption          = 0x00C00000,
            Child            = 0x40000000,
            ChildWindow      = 0x40000000,
            Clipchildren     = 0x02000000,
            ClipSiblings     = 0x04000000,
            Disabled         = 0x08000000,
            DlgFrame         = 0x00400000,
            Group            = 0x00020000,
            HScroll          = 0x00100000,
            Iconic           = 0x20000000,
            Maximize         = 0x01000000,
            MaximizeBox      = 0x00010000,
            Minimize         = 0x20000000,
            MinimizeBox      = 0x00020000,
            Overlapped       = 0x00000000,
            OverlappedWindow = Overlapped | Caption | SysMenu | ThickFrame | MinimizeBox | MaximizeBox,
            Popup            = 0x80000000,
            PopupWindow      = Popup | Border | SysMenu,
            SizeBox          = 0x00040000,
            SysMenu          = 0x00080000,
            TabStop          = 0x00010000,
            ThickFrame       = 0x00040000,
            Tiled            = 0x00000000,
            TiledWindow      = Overlapped | Caption | SysMenu | ThickFrame | MinimizeBox | MaximizeBox,
            Visible          = 0x10000000,
            VScroll          = 0x00200000
        }

	public enum Wm : uint
	{
	    Null = 0x0000,
	    Create = 0x0001,
	    Destroy = 0x0002,
	    Move = 0x0003,
	    Size = 0x0005,
	    Activate = 0x0006,
	    SetFocus = 0x0007,
	    KillFocus = 0x0008,
	    Enable = 0x000A,
	    SetRedraw = 0x000B,
	    SetText = 0x000C,
	    GetText = 0x000D,
	    GetTextLength = 0x000E,
	    Paint = 0x000F,
	    Close = 0x0010,
	    
	    #if !(_WIN32_WCE)
	    QueryEndSession = 0x0011,
	    QueryOpen = 0x0013,
	    EndSession = 0x0016,
	    #endif
	    
	    Quit = 0x0012,
	    EraseBkgnd = 0x0014,
	    SysColorChange = 0x0015,
	    ShowWindow = 0x0018,
	    WinIniChange = 0x001A,
	    
	    #if (_WIN32_MIN_WINVER_0x0400)
	    SettingChange = WinIniChange
	    #endif
	    
	    DevModeChange = 0x001B,
	    ActivateApp = 0x001C,
	    FontChange = 0x001D,
	    TimeChange = 0x001E,
	    CancelMode = 0x001F,
	    SetCursor = 0x0020,
	    MouseActivate = 0x0021,
	    ChildActivate = 0x0022,
	    QueueSync = 0x0023,
	    GetMinMaxInfo = 0x0024,
	    
	    PaintIcon = 0x0026,
	    IconEraseBkgnd = 0x0027,
	    NextDlgCtl = 0x0028,
	    SpoolerStatus = 0x002A,
	    DrawItem = 0x002B,
	    MeasureItem = 0x002C,
	    DeleteItem = 0x002D,
	    VKeyToItem = 0x002E,
	    CharToItem = 0x002F,
	    SetFont = 0x0030,
	    GetFont = 0x0031,
	    SetHotkey = 0x0032,
	    GetHotkey = 0x0033,
	    QueryDragIcon = 0x0037,
	    CompareItem = 0x0039,
	    
	    #if (_WIN32_MIN_WINVER_0x0500)
	    #if !(_WIN32_WCE)
	    GetObject = 0x003D,
	    #endif
	    #endif
	    
	    Compacting = 0x0041,
	    Commotify = 0x0044,
	    WindowPosChanging = 0x0046,
	    WindowPosChanged = 0x0047,
	    Power = 0x0048,
	    CopyData = 0x004A,
	    CancelJournal = 0x004B,
	    
	    #if (_WIN32_MIN_WINVER_0x0400)
	    Notify = 0x004E,
	    InputLangChangeRequest = 0x0050,
	    InputLangChange = 0x0051,
	    TCard = 0x0052,
	    Help = 0x0053,
	    UserChanged = 0x0054,
	    NotifyFormat = 0x0055,
	    ContextMenu = 0x007B,
	    StyleChanging = 0x007C,
	    StyleChanged = 0x007D,
	    DisplayChange = 0x007E,
	    GetIcon = 0x007F,
	    SetIcon = 0x0080,
	    #endif

	    NcCreate = 0x0081,
	    NcDestroy = 0x0082,
	    NcCalcSize = 0x0083,
	    NcHitTest = 0x0084,
	    NcPaint = 0x0085,
	    NcActivate = 0x0086,
	    GetDlgCode = 0x0087,
	    
	    #if!(_WIN32_WCE)
	    SyncPaint = 0x0088,
	    #endif
	    
	    NcMosueMove = 0x00A0,
	    NclButtonDown = 0x00A1,
	    NclBUttonUp = 0x00A2,
	    NclButtonDblClk = 0x00A3,
	    NcrButtonDown = 0x00A4,
	    NcrButtonUp = 0x00A5,
	    NcrButtonDblClk = 0x00A6,
	    NcmButtonDown = 0x00A7,
	    NcmButtonUp = 0x00A8,
	    NcmButtonDblClk = 0x00A9
	}

        [FlagsAttribute]
        public enum Pm : uint
        {
            NoRemove = 0x0000,
            Remove   = 0x0001,
            NoYield  = 0x0002
        }

        public enum Idc : short
        {
            AppStarting = 32650,
            Arrow       = 32512,
            Cross       = 32515,
            Hand        = 32649,
            Help        = 32651,
            IBeam       = 32513,
            Icon        = 32641,
            No          = 32648,
            Size        = 32640,
            SizeAll     = 32646,
            SizeNESW    = 32643,
            SizeNS      = 32645,
            SizeNWSE    = 32642,
            SizeWE      = 32644,
            UpArrow     = 32516,
            Wait        = 32514
        }
	
        [DllImport("kernel32.dll", SetLastError=true)]
        public static extern UInt32 GetLastError();

        [DllImport("user32.dll", SetLastError=true)]
        [return: MarshalAs(UnmanagedType.U2)]
        public static extern UInt16 RegisterClass([In] ref WNDCLASS wndClass);

        [DllImport("kernel32.dll", SetLastError=true)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")]
        public static extern HANDLE GetModuleHandle([MarshalAs(UnmanagedType.LPStr)] string moduleName);

        [DllImport("gdi32.dll", SetLastError=true)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")]
        public static extern HANDLE GetStockObject(StockObject i);

        [DllImport("user32.dll", SetLastError=true)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")]
	public static extern HANDLE CreateWindowEx(Win32.WsEx extendedStyle,
						   [MarshalAs(UnmanagedType.LPStr)] string className,
						   [MarshalAs(UnmanagedType.LPStr)] string windowName,
						   Win32.Ws style,
						   uint x, uint y,
						   uint width, uint height,
						   [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")] HANDLE windowParent,
						   [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")] HANDLE menu,
						   [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")] HANDLE instance,
						   IntPtr param); // TODO(joshua): Actually replace with the correct parameter (LPVOID)

        [DllImport("user32.dll", SetLastError=true)]
	public static extern IntPtr DefWindowProc(IntPtr window,
						  uint message,
						  uint wParam,
						  uint lParam);

        [DllImport("user32.dll", SetLastError=true)]
	public static extern bool ShowWindow([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")] HANDLE window,
					     uint cmdShow);

        [DllImport("user32.dll", SetLastError=true)]
	public static extern bool PeekMessage(out MSG message, // message does not have to be initialized before being passed
					      [MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")] HANDLE window,
					      uint messageFilterMin,
					      uint messageFilterMax,
					      uint removeMessage);

        [DllImport("user32.dll", SetLastError=true)]
	public static extern bool TranslateMessage(ref MSG message);

        [DllImport("user32.dll", SetLastError=true)]
	public static extern IntPtr DispatchMessage(ref MSG message);

        [DllImport("user32.dll", SetLastError=true)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")]
	public static extern HANDLE LoadCursor([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")] HANDLE instance,
					       [MarshalAs(UnmanagedType.U2)] short cursorName);

        [DllImport("user32.dll", SetLastError=true)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")]
	public static extern HANDLE BeginPaint([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")] HANDLE window,
					       out PAINTSTRUCT paint);

        [DllImport("user32.dll", SetLastError=true)]
     	public static extern bool EndPaint([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")] HANDLE window,
					   ref PAINTSTRUCT paint);

        [DllImport("user32.dll", SetLastError=true)]
     	public static extern bool GetClientRect([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")] HANDLE window,
						ref RECT rect);

        [DllImport("user32.dll", SetLastError=true)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")]
     	public static extern HANDLE SetCursor([MarshalAs(UnmanagedType.CustomMarshaler, MarshalType="Win32API.HANDLEMarshaler")] HANDLE cursor);
    }

    public delegate IntPtr WndProc(IntPtr window, uint message, uint wParam, uint lParam);
    
    [StructLayout(LayoutKind.Sequential)]
    public struct WNDCLASS
    {
        [MarshalAs(UnmanagedType.U4)] public Win32.Cs Style;
        [MarshalAs(UnmanagedType.FunctionPtr)] public WndProc WindowProc;
        public int ClassExtra;
        public int WindowExtra;
        IntPtr _Instance;
        IntPtr _Icon;
        IntPtr _Cursor;
        IntPtr _Background;
        [MarshalAs(UnmanagedType.LPStr)] public string MenuName; 
        [MarshalAs(UnmanagedType.LPStr)] public string ClassName; 
                                                                
        public void Instance(HINSTANCE value) { this._Instance = value.Value; }
        public HINSTANCE Instance() { return(new HINSTANCE(this._Instance)); }
	
        public void Icon(HANDLE value) { this._Icon = value.Value; }
        public HANDLE Icon() { return(new HANDLE(this._Icon)); }
	
        public void Cursor(HANDLE value) { this._Cursor = value.Value; }
        public HANDLE Cursor() { return(new HANDLE(this._Cursor)); }
        
        public void Background(HANDLE value) { this._Background = value.Value; }
        public HANDLE Background() { return(new HANDLE(this._Background)); }
    }

    public enum StockObject : int
    {
        WhiteBrush = 0,
        LtGrayBrush = 1,
        GrayBrush = 2,
        DkgGrayBrush = 3,
        BlackBrush = 4,
        NullBrush = 5,
        HollowBrush = NullBrush,
        WhitePen = 6,
        BlackPen = 7,
        NullPen = 8,
        OemFixedFont = 10,
        AnsiFixedFont = 11,
        AnsiVarFont = 12,
        DefaultGuiFont = 14,
        DefaultPalette = 15,
        SystemFixedFont = 16,
        DeviceDefaultFont = 17,
        DCBrush = 18,
        DCPen = 19
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        IntPtr _Window;
	public uint Message;
	public uint WParam;
	public uint LParam;
	UInt32 _Time;
	public IntPtr Point;
	UInt32 _Private;

	public void Window(HWND value) { this._Window = value.Value; }
	public HWND Window() { return(new HWND(this._Window)); }
	
	public void Time(DWORD value) { this._Time = value.Value; }
	public DWORD Time() { return(new DWORD(this._Time)); }

	public void Private(DWORD value) { this._Private = value.Value; }
	public DWORD Private() { return(new DWORD(this._Private)); }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PAINTSTRUCT
    {
	IntPtr _Window;
	public bool Erase;
	public RECT Paint;
	public bool Restore;
	public bool IncUpdate;
	[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)] public byte [] RgbReserved;

	public void Window(HDC value) { this._Window = value.Value; }
	public HDC Window() { return(new HDC(this._Window)); }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
	public Int32 Left;
	public Int32 Top;
	public Int32 Right;
	public Int32 Bottom;
    }
}
