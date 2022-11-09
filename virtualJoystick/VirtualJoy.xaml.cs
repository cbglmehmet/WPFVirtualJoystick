using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace virtualJoystick
{
    /// <summary>
    /// Interaction logic for VirtualJoy.xaml
    /// </summary>
    public partial class VirtualJoy : UserControl
    {
        public VirtualJoy()
        {
            InitializeComponent();
        }
        private int _xValue = 50;
        private int _yValue = 50;
        public int X
        {
            get
            {
                return _xValue;
            }
        }

        public int Y
        {
            get
            {
                return _yValue;
            }
        }



        UIElement _source = null;
        double _xShape, _xCanvas, _yShape, _yCanvas;
        bool _captured = false;
        int _joyXLocation = 100;
        int _joyYLocation = 100;
        int _width = 300;
        int _height = 300;
        int _stickwidth = 60;
        float _mouseX = 0;
        float _mouseY = 0;
        int _mcx = 0;
        int _mcy = 0;
        bool _fingerInBounds = false;
        float _fingerDistance2 = 0;
        float _distanceBound = 0;
        float _distanceBound2 = 0;


        private void Joystick_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _source = (UIElement)sender;
            _xCanvas = e.GetPosition(LayoutRoot).X;
            _yCanvas = e.GetPosition(LayoutRoot).Y;
            Canvas.SetTop(joystick, _yCanvas - 5);
            Canvas.SetLeft(joystick, _xCanvas - 7);
            Mouse.Capture(_source);
            _captured = true;
            _xShape = Canvas.GetLeft(_source);
            _yShape = Canvas.GetTop(_source);
        }
        private void Joystick_MouseMove(object sender, MouseEventArgs e)
        {
            if (_captured)
            {
               
                _mouseX = (float)e.GetPosition(LayoutRoot).X;
                _mouseY = (float)e.GetPosition(LayoutRoot).Y;
                _mcx = Convert.ToInt32(_mouseX - _width * 0.5);
                _mcy = Convert.ToInt32(_mouseY - _height * 0.5);
                _fingerDistance2 = _mcx * _mcx + _mcy * _mcy;
                _distanceBound = (float)(_width * 0.5 - _stickwidth * 0.1);
                _distanceBound2 = _distanceBound * _distanceBound;
                if (_fingerDistance2 < _distanceBound2 )
                {
                    _fingerInBounds = true;
                }
                else
                {
                    _fingerInBounds = false;
                }

                _mouseX -= 20;
                _mouseY -= 20;

                if (_fingerInBounds)
                {
                    _xShape += _mouseX - _xCanvas;
                    Canvas.SetLeft(_source, _xShape);
                    _xCanvas = _mouseX;

                    _yShape += _mouseY - _yCanvas;
                    Canvas.SetTop(_source, _yShape);
                    _yCanvas = _mouseY;

                    _joyXLocation = (int)_mouseX + 20;
                    _joyYLocation = (int)_mouseY + 20;

                    if(_joyXLocation < 0) { _joyXLocation = 0; }
                    if(_joyXLocation > _width) { _joyXLocation = _width; }

                    if (_joyYLocation < 0) { _joyYLocation = 0; }
                    if (_joyYLocation > _height) { _joyYLocation = _height; }

                    _xValue = valueScale(_joyXLocation,0, _width, 0,100);
                    _yValue = valueScale(_joyYLocation,0, _height, 0,100);
                }
                
            }
        }
        private int valueScale(int valueIn, int baseMin, int baseMax, int limitMin, int limitMax)
        {
            return ((limitMax - limitMin) * (valueIn - baseMin) / (baseMax - baseMin)) + limitMin;
        }
        private void Joystick_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _xShape = 100;
            _yShape = 100;
            _xCanvas = 100;
            _yCanvas = 100;
            Mouse.Capture(null);
            _captured = false;
            Canvas.SetTop(joystick, 120);
            Canvas.SetLeft(joystick, 120);
            _joyXLocation = 100;
            _joyYLocation = 100;
            _xValue = 50;
            _yValue = 50;
        }
    }
}
