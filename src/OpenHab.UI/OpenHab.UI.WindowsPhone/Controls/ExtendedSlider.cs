﻿using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

namespace OpenHab.UI.Controls
{
    public class SliderValueChangeCompletedEventArgs : RoutedEventArgs
    {
        private readonly double _value;

        public double Value { get { return _value; } }

        public SliderValueChangeCompletedEventArgs(double value)
        {
            _value = value;
        }
    }
    public delegate void SlideValueChangeCompletedEventHandler(object sender, SliderValueChangeCompletedEventArgs args);


    public class ExtendedSlider : Slider
    {
        public event SlideValueChangeCompletedEventHandler ValueChangeCompleted;
        
        private bool _isDragging = false;

        protected void OnValueChangeCompleted(double value)
        {
            var handler = ValueChangeCompleted;
            if (handler != null)
                handler(this, new SliderValueChangeCompletedEventArgs(value));
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var thumb = base.GetTemplateChild("HorizontalThumb") as Thumb;
            if (thumb != null)
            {
                thumb.DragStarted += ThumbOnDragStarted;
                thumb.DragCompleted += ThumbOnDragCompleted;
            }
            thumb = base.GetTemplateChild("VerticalThumb") as Thumb;
            if (thumb != null)
            {
                thumb.DragStarted += ThumbOnDragStarted;
                thumb.DragCompleted += ThumbOnDragCompleted;
            }
        }

        private void ThumbOnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            Debug.WriteLine("Drag completed");

            _isDragging = false;
            OnValueChangeCompleted(this.Value);
        }

        private void ThumbOnDragStarted(object sender, DragStartedEventArgs e)
        {
            _isDragging = true;
        }

        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);

            if (!_isDragging)
            {
                Debug.WriteLine("value changed");
                OnValueChangeCompleted(newValue);
            }
        }
    }
}
