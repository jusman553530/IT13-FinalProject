using System.Windows.Forms;

namespace CRM.winforms
{
    public partial class AdminPlaceholderControl : UserControl
    {
        public AdminPlaceholderControl(string pageTitle)
        {
            InitializeComponent();

            lblTitle.Text = pageTitle;
            lblSubtitle.Text = "Coming soon";
            lblBody.Text = pageTitle + "\n\nThis page will be built soon.";
        }
    }
}