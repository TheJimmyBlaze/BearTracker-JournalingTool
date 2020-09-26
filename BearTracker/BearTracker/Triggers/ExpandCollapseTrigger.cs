using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BearTracker.Triggers
{
    public class ExpandCollapseTrigger : TriggerAction<Frame>
    {
        public enum AnimationAction
        {
            Collapse,
            Expand
        };

        public enum AnimationOrientation
        {
            Horizontal,
            Vertical
        };

        public AnimationAction Action { get; set; }
        public AnimationOrientation Orientation { get; set; }

        public int MaxSize { get; set; }
        public int MinSize { get; set; }

        protected override void Invoke(Frame sender)
        {
            if (MaxSize == 0 && MinSize == 0)
                throw new ArgumentException("MaxWidth and MinWidth shouldn't both be 0, it's pointless to do this.");

            if (Action == AnimationAction.Expand)
                PerformExpand(sender);
            else
                PerformCollapse(sender);
        }

        private void PerformExpand(Frame frame)
        {
            Animation scale = new Animation(size => ResizeCallback(frame, size), MinSize, MaxSize, Easing.SpringOut);
            scale.Commit(frame, "Expand", 16, 500);
        }

        private void PerformCollapse(Frame frame)
        {
            Animation scale = new Animation(size => ResizeCallback(frame, size), MaxSize, MinSize, Easing.SpringIn);
            scale.Commit(frame, "Collapse", 16, 500);
        }

        private void ResizeCallback(Frame frame, double size)
        {
            switch (Orientation)
            {
                case AnimationOrientation.Horizontal:
                    frame.WidthRequest = size;
                    break;
                case AnimationOrientation.Vertical:
                    frame.HeightRequest = size;
                    break;
            }
        }
    }
}
