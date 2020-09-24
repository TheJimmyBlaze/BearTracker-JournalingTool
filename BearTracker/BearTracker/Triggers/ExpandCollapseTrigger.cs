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

        public AnimationAction Action { get; set; }
        public int MaxWidth { get; set; }
        public int MinWidth { get; set; }

        protected override void Invoke(Frame sender)
        {
            if (MaxWidth == 0 && MinWidth == 0)
                throw new ArgumentException("MaxWidth and MinWidth shouldn't both be 0, it's pointless to do this.");

            if (Action == AnimationAction.Expand)
                PerformExpand(sender);
            else
                PerformCollapse(sender);
        }

        private void PerformExpand(Frame frame)
        {
            Animation scale = new Animation(width => frame.WidthRequest = width, MinWidth, MaxWidth, Easing.SpringOut);
            scale.Commit(frame, "Expand", 16, 500);
        }

        private void PerformCollapse(Frame frame)
        {
            Animation scale = new Animation(width => frame.WidthRequest = width, MaxWidth, MinWidth, Easing.SpringIn);
            scale.Commit(frame, "Collapse", 16, 500);
        }
    }
}
