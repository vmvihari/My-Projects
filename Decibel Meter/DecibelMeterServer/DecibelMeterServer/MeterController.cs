using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DecibelMeter
{
    public partial class MeterController : UserControl
    {
        // Rectangle box objects for drawing the meter
        // MeterOuterRect : Object to set the dimensions for the outline of the meter
        private Rectangle MeterOuterRect;

        // MeterInnerRect : Object to set the dimensions of the inner part of the meter
        private Rectangle MeterInnerRect;

        // MeterNoiseLevel : Object to set the dimensions for filling the meter as noise level increases
        private Rectangle MeterNoiseLevel;

        private Brush bshMeterController;
        private Bitmap mcBitSurface;        
        private Graphics gfxMeterController;
        private Brush bshMeterControllerRare = Brushes.White;
        private LinearGradientBrush lgbMeterController;

        private bool blCheck;
        [Category("Appearance")]
        public bool BlCheck
        {
            get
            {
                return blCheck;
            }
            set
            {
                blCheck = value;
                TransformMeter();
                Invalidate();
            }
        }

        private Color clrMeterController = Color.CornflowerBlue;
        [Category("Appearance")]
        public Color ClrMeterController
        {
            get
            {
                return clrMeterController;
            }
            set
            {
                clrMeterController = value;
                AdjustMeterColor(value);
                bshMeterController = new SolidBrush(clrMeterController);
                Invalidate();
            }
        }

        private float mcNoise = 0f;
        [Category("Dimension Percents")]
        public int McNoise
        {
            get
            {
                return (int)(mcNoise * 100f + 0.5f);
            }
            set
            {
                if (value > 100)
                {
                    mcNoise = 1;
                }
                else if (value < 0)
                {
                    mcNoise = 0;
                }
                else
                {
                    mcNoise = value / 100f;
                }

                DrawMeterColor();
                Invalidate();
            }
        }

        private float mcGraphicsWidth = 0.08f;
        [Category("Dimension Percents")]
        public int McGraphicsWidth
        {
            get
            {
                return (int)(mcGraphicsWidth * 100f + 0.5f);
            }
            set
            {
                if (value > 30)
                {
                    mcGraphicsWidth = 0.3f;
                }
                else if (value < 0)
                {
                    mcGraphicsWidth = 0;
                }
                else
                {
                    mcGraphicsWidth = value / 100f;
                }

                DrawMeterColor();
                Invalidate();
            }
        }

        private float mcGraphicsHeight = 0.27f;
        [Category("Dimension Percents")]
        public int McGraphicsHeight
        {
            get
            {
                return (int)(mcGraphicsHeight * 100f + 0.5f);
            }
            set
            {
                if (value > 90)
                {
                    mcGraphicsHeight = 0.9f;
                }
                else if (value < 0)
                {
                    mcGraphicsHeight = 0;
                }
                else
                {
                    mcGraphicsHeight = value / 100f;
                }

                DrawMeterColor();
                Invalidate();
            }
        }

        private float mcGraphicsPressure = 0.02f;
        [Category("Dimension Percents")]
        public int McGraphicsPressure
        {
            get
            {
                return (int)(mcGraphicsPressure * 100f + 0.5f);
            }
            set
            {
                if (value > 10)
                {
                    mcGraphicsPressure = 0.1f;
                }
                else if (value < 0)
                {
                    mcGraphicsPressure = 0;
                }
                else
                {
                    mcGraphicsPressure = value / 100f;
                }

                DrawMeterColor();
                Invalidate();
            }
        }

        private float mcGraphicsStuff = 0.02f;
        [Category("Dimension Percents")]
        public int McGraphicsStuff
        {
            get
            {
                return (int)(mcGraphicsStuff * 100f + 0.5f);
            }
            set
            {
                if (value > 10)
                {
                    mcGraphicsStuff = 0.1f;
                }
                else if (value < 0)
                {
                    mcGraphicsStuff = 0;
                }
                else
                {
                    mcGraphicsStuff = value / 100f;
                }

                DrawMeterColor();
                Invalidate();
            }
        }

        public MeterController()
        {
            Size = new Size(100, 50);
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            AdjustMeterColor(clrMeterController);
            bshMeterController = new SolidBrush(clrMeterController);
            DrawMeterColor();
        }

        private void AdjustMeterColor(Color color)
        {
            Rectangle rect = new Rectangle(Point.Empty, new Size(Width, Height / 2));
            lgbMeterController = new LinearGradientBrush(rect, color, SetColorFactor(color, 1.2f), 90f) { WrapMode = WrapMode.TileFlipX };
        }

        private void DrawMeterColor()
        {
            // Draw the outline of the meter controller
            int mcNodeWidth = (int)(Width * mcGraphicsWidth + 0.5);
            MeterOuterRect.Width = Width - mcNodeWidth;
            MeterOuterRect.Height = Height;
            MeterOuterRect.X = mcNodeWidth;
            MeterOuterRect.Y = 0;

            // Draw the inner meter of the meter controller
            int mcPressure = ((int)(Width * mcGraphicsPressure + 0.5)) * 2;
            MeterInnerRect.Width = Width - (mcNodeWidth + (mcPressure * 2));
            MeterInnerRect.Height = Height - mcPressure * 2;
            MeterInnerRect.X = mcNodeWidth + mcPressure;
            MeterInnerRect.Y = mcPressure;

            // Set the initial nooise level for the meter controller
            int mcStuff = (int)(Width * mcGraphicsStuff + 0.5);
            MeterNoiseLevel.Width = MeterInnerRect.Width - mcStuff * 2;
            int lastWidth = MeterNoiseLevel.Width;
            MeterNoiseLevel.Width = (int)(MeterNoiseLevel.Width * mcNoise + 0.5f);
            MeterNoiseLevel.Height = MeterInnerRect.Height - mcStuff * 2;

            // Update the noise level for the meter controller
            MeterNoiseLevel.X = MeterInnerRect.X + mcStuff;
            MeterNoiseLevel.X += lastWidth - MeterNoiseLevel.Width;
            MeterNoiseLevel.Y = MeterInnerRect.Y + mcStuff;
        }

        private void SetMeterGraphics()
        {
            mcBitSurface = new Bitmap(Width, Height);
            gfxMeterController = Graphics.FromImage(mcBitSurface);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AdjustMeterColor(clrMeterController);
            SetMeterGraphics();
        }

        private static Color SetColorFactor(Color mcColor, float mcFactor)
        {
            float clrRed = mcColor.R * mcFactor;
            if (clrRed > 255)
            {
                clrRed = 255;
            }

            float clrGreen = mcColor.G * mcFactor;
            if (clrGreen > 255)
            {
                clrGreen = 255;
            }

            float clrBlue = mcColor.B * mcFactor;
            if (clrBlue > 255)
            {
                clrBlue = 255;
            }
            return Color.FromArgb(mcColor.A, (int)clrRed, (int)clrGreen, (int)clrBlue);
        }

        // Translate and rotate the meter
        private void TransformMeter()
        {
            gfxMeterController.TranslateTransform((float)Width / 2, (float)Height / 2);
            gfxMeterController.RotateTransform(180);
            gfxMeterController.TranslateTransform(-(float)Width / 2, -(float)Height / 2);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            bshMeterControllerRare = new SolidBrush(BackColor);
            base.OnBackColorChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawMeterColor();

            gfxMeterController.Clear(BackColor);
            gfxMeterController.FillRectangle(bshMeterController, MeterOuterRect);
            gfxMeterController.FillRectangle(bshMeterControllerRare, MeterInnerRect);
            gfxMeterController.FillRectangle(lgbMeterController, MeterNoiseLevel);

            e.Graphics.DrawImageUnscaled(mcBitSurface, Point.Empty);
        }
    }
}
