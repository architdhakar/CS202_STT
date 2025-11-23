using System;

namespace EventPlayground
{
    public class ColorEventArgs : EventArgs
    {
        public string SelectedColor { get; }

        public ColorEventArgs(string color)
        {
            SelectedColor = color;
        }
    }
}
