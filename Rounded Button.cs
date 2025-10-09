using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Wiring_Desk
{
    public partial class Rounded_Button : UserControl
    {
        private LinearGradientBrush _brush;
        private string _text = string.Empty;
        private Color _startColor = Color.FromArgb(255, 255, 255, 0); // Default red
        private Color _endColor = Color.FromArgb(255, 255, 255, 255); // Default blue
        private int _cornerRadius = 20; // Default corner radius
        private Color _foreColor = Color.Black; // Default text color
        private bool _isHovered = false;
        private bool _isClicked = false;

        // Custom hover colors
        private Color _hoverStartColor = Color.FromArgb(255, 255, 255, 255); // Green
        private Color _hoverEndColor = Color.FromArgb(255, 255, 255, 0); // Blue

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get => _text;
            set
            {
                _text = value;
                Invalidate(); // Redraw when text is updated
            }
        }

        [Description("The radius of the button's corners.")]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = value;
                Invalidate(); // Redraw immediately when corner radius is updated
            }
        }

        [Description("The start color of the gradient.")]
        public Color StartColor
        {
            get => _startColor;
            set
            {
                _startColor = value;
                UpdateGradientBrush();
                Invalidate(); // Redraw immediately when start color is updated
            }
        }

        [Description("The end color of the gradient.")]
        public Color EndColor
        {
            get => _endColor;
            set
            {
                _endColor = value;
                UpdateGradientBrush();
                Invalidate(); // Redraw immediately when end color is updated
            }
        }

        [Description("The color of the text.")]
        public override Color ForeColor
        {
            get => _foreColor;
            set
            {
                _foreColor = value;
                Invalidate(); // Redraw immediately when text color (forecolor) is updated
            }
        }

        [Description("The color of the text.")]
        public Color HoverStartColor
        {
            get => _hoverStartColor;
            set
            {
                _hoverStartColor = value;
                Invalidate(); // Redraw immediately when text color (forecolor) is updated
            }
        }


        [Description("The color of the text.")]
        public Color HoverEndColor
        {
            get => _hoverEndColor;
            set
            {
                _hoverEndColor = value;
                Invalidate(); // Redraw immediately when text color (forecolor) is updated
            }
        }

        // Use the base Font property of UserControl
        [Description("The font used to display the text.")]
        public override Font Font
        {
            get => base.Font; // This will now return the UserControl's Font property
            set
            {
                base.Font = value; // Set the UserControl's Font
                Invalidate(); // Redraw when font is updated
            }
        }

        public Rounded_Button()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent; // Transparent background
            this.DoubleBuffered = true; // Reduce flickering
            UpdateGradientBrush(); // Initialize the gradient brush
        }

        private void UpdateGradientBrush()
        {
            // If the button is hovered, use hover colors
            if (_isHovered)
            {
                _brush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), _hoverStartColor, _hoverEndColor, LinearGradientMode.Vertical);
            }
            else
            {
                // Default gradient
                _brush = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), _startColor, _endColor, LinearGradientMode.Vertical);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
         {
             base.OnPaint(e);
             Graphics graphics = e.Graphics;
             graphics.SmoothingMode = SmoothingMode.AntiAlias;

             // Draw background with rounded corners
             using (GraphicsPath path = new GraphicsPath())
             {
                 path.AddArc(new Rectangle(0, 0, _cornerRadius, _cornerRadius), 180, 90);
                 path.AddArc(new Rectangle(Width - _cornerRadius, 0, _cornerRadius, _cornerRadius), 270, 90);
                 path.AddArc(new Rectangle(Width - _cornerRadius, Height - _cornerRadius, _cornerRadius, _cornerRadius), 0, 90);
                 path.AddArc(new Rectangle(0, Height - _cornerRadius, _cornerRadius, _cornerRadius), 90, 90);
                 path.CloseAllFigures();

                 // Fill the background with the gradient
                 graphics.FillPath(_brush, path);

                 // Draw border (optional)
                 using (Pen pen = new Pen(Color.Black, 2))
                 {
                     graphics.DrawPath(pen, path);
                 }
             }

             // Center and draw text with the specified ForeColor and Font
             SizeF fontSize = graphics.MeasureString(_text, this.Font); // Use the base UserControl Font
             float x = (Width - fontSize.Width) / 2;
             float y = (Height - fontSize.Height) / 2;
             using (SolidBrush textBrush = new SolidBrush(_foreColor)) // Use the editable ForeColor property
             {
                 graphics.DrawString(_text, this.Font, textBrush, new PointF(x, y)); // Use the base UserControl Font
             }
         }
        
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateGradientBrush(); // Recalculate the gradient brush on resize
            Invalidate(); // Redraw on resize
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            UpdateGradientBrush(); // Update brush to hover gradient
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            UpdateGradientBrush(); // Reset brush to default gradient
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _isClicked = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _isClicked = false;
            Invalidate();
        }

        private void Rounded_Button_Load(object sender, EventArgs e)
        {
           
        }
    }
}
