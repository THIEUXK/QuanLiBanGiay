﻿using System.Drawing.Drawing2D;

namespace C_GUI.RJControls
{
    public class RJDatePicker : DateTimePicker
    {
        //Fields
        //-> Appearance
        private Color skinColor = Color.MediumSlateBlue;
        private Color textColor = Color.White;
        private Color borderColor = Color.PaleVioletRed;
        private int borderSize = 2;

        //-> Other Values
        private bool droppedDown = false;
        private Image calendarIcon = Properties.Resources.calendarWhite;
        private RectangleF iconButtonArea;
        private const int calendarIconWidth = 34;
        private const int arrowIconWidth = 17;

        //Properties
        public Color SkinColor
        {
            get => skinColor;
            set
            {
                skinColor = value;
                calendarIcon = skinColor.GetBrightness() >= 0.6F
                    ? Properties.Resources.calendarDark
                    : Properties.Resources.calendarWhite;
                Invalidate();
            }
        }

        public Color TextColor
        {
            get => textColor;
            set
            {
                textColor = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public int BorderSize
        {
            get => borderSize;
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        //Constructor
        public RJDatePicker()
        {
            SetStyle(ControlStyles.UserPaint, true);
            MinimumSize = new Size(0, 35);
            Font = new Font(Font.Name, 9.5F);
        }

        //Overridden methods
        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            droppedDown = true;
        }
        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            droppedDown = false;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using Graphics graphics = CreateGraphics();
            using Pen penBorder = new(borderColor, borderSize);
            using SolidBrush skinBrush = new(skinColor);
            using SolidBrush openIconBrush = new(Color.FromArgb(50, 64, 64, 64));
            using SolidBrush textBrush = new(textColor);
            using StringFormat textFormat = new();
            RectangleF clientArea = new(0, 0, Width - 0.5F, Height - 0.5F);
            RectangleF iconArea = new(clientArea.Width - calendarIconWidth, 0, calendarIconWidth, clientArea.Height);
            penBorder.Alignment = PenAlignment.Inset;
            textFormat.LineAlignment = StringAlignment.Center;

            //Draw surface
            graphics.FillRectangle(skinBrush, clientArea);
            //Draw text
            graphics.DrawString("   " + Text, Font, textBrush, clientArea, textFormat);
            //Draw open calendar icon highlight
            if (droppedDown == true)
            {
                graphics.FillRectangle(openIconBrush, iconArea);
            }
            //Draw border 
            if (borderSize >= 1)
            {
                graphics.DrawRectangle(penBorder, clientArea.X, clientArea.Y, clientArea.Width, clientArea.Height);
            }
            //Draw icon
            graphics.DrawImage(calendarIcon, Width - calendarIcon.Width - 9, (Height - calendarIcon.Height) / 2);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            iconButtonArea = new RectangleF(Width - iconWidth, 0, iconWidth, Height);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Cursor = iconButtonArea.Contains(e.Location) ? Cursors.Hand : Cursors.Default;
        }

        //Private methods
        private int GetIconButtonWidth()
        {
            int textWidh = TextRenderer.MeasureText(Text, Font).Width;
            return textWidh <= Width - (calendarIconWidth + 20) ? calendarIconWidth : arrowIconWidth;
        }
    }
}
