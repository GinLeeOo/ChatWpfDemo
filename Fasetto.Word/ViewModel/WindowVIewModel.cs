
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word
{
    /// <summary>
    /// this View Model for the Custom flat window
    /// </summary>
    public class WindowVIewModel:BaseViewModel
    {

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaxmizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }


        public double WindowMiniNumWidth { get; set; } = 400;

        public double WindowMiniNumHeight { get; set; } = 400;


        /// <summary>
        /// The Margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 5;//10

        /// <summary>
        /// The radius  of the edges for the window
        /// </summary>
        private int mWindowRadius = 10;
        /// <summary>
        /// The Size of the Resize Border around the Window
        /// </summary>
        private int ResizeBorder= 6;//6

        //public bool BorderLess { get { return  mWindow.WindowState == WindowState.Minimized || mDockPosition != WindowDockPosition.Undocked } };

        //public int ResizeBorder { get { return  Bor ?? 0:} }

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder+ mOuterMarginSize); }  }


        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// The Margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize; }
            set
            {
                mOuterMarginSize = value;
            }
        }
        public Thickness OuterMarginSizeThickness
        {
            get { return new Thickness(OuterMarginSize); }         
        }

        public int WindowRadius
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius; }
            set
            {
                mWindowRadius = value;
            }
        }
        public CornerRadius WindowCornerRadius
        {
            get { return new CornerRadius(OuterMarginSize); }         
        }

        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength
        {
            get { return new GridLength(TitleHeight+ResizeBorder); }
        }

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
        public WindowVIewModel(Window window)
        {
            mWindow = window;
            mWindow.StateChanged += (sender, e) =>
            {                
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowCornerRadius));
                OnPropertyChanged(nameof(WindowRadius));
            };
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaxmizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(()=>SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

                                            
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        public  Point GetMousePosition()
        {
            var position = Mouse.GetPosition(mWindow);
           return new Point(position.X+mWindow.Left, position.Y+mWindow.Top);
            return new Point(position.X , position.Y );
        }



        private Window mWindow;

       // public string myText { get; set; } = "My Text";
    }

}
