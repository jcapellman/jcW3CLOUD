using jcW3CLOUD.PCL;
using jcW3CLOUD.PCL.BaseControls;
using jcW3CLOUD.UWP.PCL.Controls;

namespace jcW3CLOUD.UWP.PCL {
    public class UWPControls : BaseControlImplementation {
        public override BaseLabelControl GetLabelControl() {
            return new LabelControl();
        }
    }
}