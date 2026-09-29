using System.Drawing;

namespace CRM.winforms.UI
{
    public static class Theme
    {
        public static Color Background { get; } = Color.FromArgb(245, 247, 250);
        public static Color Card { get; } = Color.White;
        public static Color Field { get; } = Color.FromArgb(248, 249, 251);
        public static Color Border { get; } = Color.FromArgb(220, 224, 230);
        public static Color Primary { get; } = Color.FromArgb(30, 90, 65);
        public static Color PrimaryHover { get; } = Color.FromArgb(24, 74, 53);
        public static Color Accent { get; } = Color.FromArgb(230, 110, 45);
        public static Color Tint { get; } = Color.FromArgb(210, 230, 220);
        public static Color Sidebar { get; } = Color.FromArgb(20, 30, 25);
        public static Color SidebarHover { get; } = Color.FromArgb(35, 50, 42);
        public static Color Danger { get; } = Color.FromArgb(200, 60, 60);
        public static Color TextDark { get; } = Color.FromArgb(35, 40, 45);
    }
}