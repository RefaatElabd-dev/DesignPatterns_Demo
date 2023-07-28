using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;
using System.Threading.Tasks;

namespace Observable.Ex2_WeakEvent
{
    // an event subscription can lead to a memory
    // leak if you hold on to it past the object's
    // lifetime

    // weak events help with this

    public class Button
    {
        public event EventHandler? Click;
        public void Fire()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }
    public class Window {
        Button button;
        public Window(Button button)
        {
            this.button = button;
            this.button.Click += ButtonOnClick;
        }

        private void ButtonOnClick(object? sender, EventArgs e)
        {
            Console.WriteLine("Window Button Clicked");
        }

        ~Window() {
            this.button.Click -= ButtonOnClick;
            Console.WriteLine("Window Object Freed");
        }
    }

    public class Window2
    {
        public Window2(Button button)
        {
            //    WeakEventManager<Button, EventArgs>
            //   .AddHandler(button, "Clicked", ButtonOnClicked);
        }

        private void ButtonOnClick(object? sender, EventArgs e)
        {
            Console.WriteLine("Window Button Clicked");
        }

        ~Window2()
        {
            Console.WriteLine("Window Object Freed");

        }
    }
}
