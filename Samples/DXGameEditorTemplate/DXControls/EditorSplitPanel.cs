using System.Windows.Forms;

namespace DXControls
{
    public partial class EditorSplitPanel : UserControl
    {
        public EditorSplitPanel()
        {
            InitializeComponent();
        }

        private bool leftCollapsed;
        private bool rightCollapsed;
        private bool topCollapsed;
        private bool bottomCollapsed;
        private bool gameMode = false;
        public bool GameMode
        {
            get { return this.gameMode; }
            set
            {
                if ( value != this.gameMode )
                {
                    if ( value )
                    {
                        this.leftCollapsed = LeftPanelCollapsed;
                        this.rightCollapsed = RightPanelCollapsed;
                        this.topCollapsed = TopPanelCollapsed;
                        this.bottomCollapsed = BottomPanelCollapsed;
                        LeftPanelCollapsed = true;
                        RightPanelCollapsed = true;
                        TopPanelCollapsed = true;
                        BottomPanelCollapsed = true;
                    }
                    else
                    {
                        LeftPanelCollapsed = this.leftCollapsed;
                        RightPanelCollapsed = this.rightCollapsed;
                        TopPanelCollapsed = this.topCollapsed;
                        BottomPanelCollapsed = this.bottomCollapsed;
                    }
                    this.gameMode = value;
                }
            }
        }

        public Control LeftPanel { get { return this.splitLeft.Panel1; } }

        public Control TopPanel { get { return this.splitTop.Panel1; } }

        public Control RightPanel { get { return this.splitRight.Panel2; } }

        public Control BottomPanel { get { return this.splitBottom.Panel2; } }

        public Control CenterPanel { get { return this.splitTop.Panel2; } }

        public SplitContainer LeftSplit { get { return this.splitLeft; } }

        public SplitContainer RightSplit { get { return this.splitRight; } }

        public SplitContainer TopSplit { get { return this.splitTop; } }

        public SplitContainer BottomSplit { get { return this.splitBottom; } }

        public bool LeftPanelCollapsed
        {
            get { return LeftSplit.Panel1Collapsed; }
            set { LeftSplit.Panel1Collapsed = value; }
        }

        public bool RightPanelCollapsed
        {
            get { return RightSplit.Panel2Collapsed; }
            set { RightSplit.Panel2Collapsed = value; }
        }

        public bool TopPanelCollapsed
        {
            get { return TopSplit.Panel1Collapsed; }
            set { TopSplit.Panel1Collapsed = value; }
        }

        public bool BottomPanelCollapsed
        {
            get { return BottomSplit.Panel2Collapsed; }
            set { BottomSplit.Panel2Collapsed = value; }
        }
    }
}
