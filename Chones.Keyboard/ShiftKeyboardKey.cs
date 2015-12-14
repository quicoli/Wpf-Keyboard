﻿using System.Windows;

namespace Chones.Keyboard
{
    public class ShiftKeyboardKey : KeyboardKey
    {
        public static readonly DependencyProperty IsShiftLockingProperty =
            DependencyProperty.RegisterAttached(nameof(IsShiftLocking), typeof(object), typeof(ShiftKeyboardKey),
                new PropertyMetadata(false));

        public bool IsShiftLocking
        {
            get { return (bool)GetValue(IsShiftLockingProperty); }
            set { SetValue(IsShiftLockingProperty, value); }
        }

        static ShiftKeyboardKey()
        { DefaultStyleKeyProperty.OverrideMetadata(typeof(ShiftKeyboardKey), new FrameworkPropertyMetadata(typeof(ShiftKeyboardKey))); }

        protected override void OnClick()
        {
            base.OnClick();

            var eventArgs = new KeyboardShiftStateModifiedRoutedEventArgs(KeyboardKey.ShiftModifiedEvent, this, !this.IsShifted, IsShiftLocking);
            RaiseEvent(eventArgs);
        }
    }
}
