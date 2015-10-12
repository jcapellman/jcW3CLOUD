namespace jcW3CLOUD.PCL.BaseControls {
    public abstract class BaseLabelControl : BaseControl {
        public string LabelContent;

        public bool IsFullScreen;

        public abstract dynamic GetPlatformControl();
    }
}