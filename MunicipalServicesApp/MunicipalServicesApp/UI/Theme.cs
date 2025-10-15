using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public static class Theme
    {
        // Neutral “municipal” palette
        private static readonly Color Bg = Color.FromArgb(246, 248, 250);     // light background
        private static readonly Color PanelBg = Color.White;                  // cards/panels
        private static readonly Color Accent = Color.FromArgb(33, 96, 158);   // primary (blue)
        private static readonly Color AccentHover = Color.FromArgb(25, 75, 124);
        private static readonly Color Text = Color.FromArgb(34, 34, 34);
        private static readonly Font UiFont = new Font("Segoe UI", 10F, FontStyle.Regular);

        public static void Apply(Form form)
        {
            form.Font = UiFont;
            form.BackColor = Bg;

            // Optional: minimum window size for nicer layout
            if (form.MinimumSize.Width == 0) form.MinimumSize = new Size(820, 520);

            // Walk all controls and style them
            StyleControls(form.Controls);

            // Add a StatusStrip if one doesn’t exist
            if (!form.Controls.OfType<StatusStrip>().Any())
            {
                var status = new StatusStrip { SizingGrip = false, BackColor = PanelBg };
                var msg = new ToolStripStatusLabel("Ready");
                status.Items.Add(msg);
                form.Controls.Add(status);
                status.Dock = DockStyle.Bottom;
            }
        }

        public static void SetStatus(Form form, string message)
        {
            var status = form.Controls.OfType<StatusStrip>().FirstOrDefault();
            var label = status?.Items.OfType<ToolStripStatusLabel>().FirstOrDefault();
            if (label != null) label.Text = message;
        }

        private static void StyleControls(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is Button b) StyleButton(b);
                else if (c is Label l) l.ForeColor = Text;
                else if (c is GroupBox g) StyleGroupBox(g);
                else if (c is ListView lv) StyleListView(lv);
                else if (c is ComboBox cb) StyleComboBox(cb);
                else if (c is TextBoxBase tb) StyleTextBox(tb);
                else if (c is DateTimePicker dt) StyleDateTimePicker(dt);
                else if (c is ListBox lb) StyleListBox(lb);
                else if (c is SplitContainer sp) StyleSplit(sp);

                // Panels & containers get a “card” look
                if (c is Panel || c is GroupBox)
                {
                    c.BackColor = PanelBg;
                }

                if (c.HasChildren) StyleControls(c.Controls);
            }
        }

        private static void StyleButton(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = Accent;
            b.ForeColor = Color.White;
            b.Cursor = Cursors.Hand;
            b.Padding = new Padding(6);
            b.Height = Math.Max(34, b.Height);
            b.MouseEnter += (s, e) => b.BackColor = AccentHover;
            b.MouseLeave += (s, e) => b.BackColor = Accent;
        }

        private static void StyleGroupBox(GroupBox g)
        {
            g.ForeColor = Text;
            g.Padding = new Padding(10);
        }

        private static void StyleListView(ListView lv)
        {
            lv.BackColor = Color.White;
            lv.ForeColor = Text;
            lv.FullRowSelect = true;
            lv.GridLines = true;
            lv.HideSelection = false;
            lv.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void StyleComboBox(ComboBox cb)
        {
            cb.FlatStyle = FlatStyle.Standard;
            cb.BackColor = Color.White;
            cb.ForeColor = Text;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private static void StyleDateTimePicker(DateTimePicker dt)
        {
            dt.CalendarMonthBackground = Color.White;
            dt.CalendarForeColor = Text;
        }

        private static void StyleTextBox(TextBoxBase tb)
        {
            tb.BackColor = Color.White;
            tb.ForeColor = Text;
            tb.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void StyleListBox(ListBox lb)
        {
            lb.BackColor = Color.White;
            lb.ForeColor = Text;
            lb.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void StyleSplit(SplitContainer sp)
        {
            sp.BackColor = Bg;
            sp.Panel1.BackColor = Bg;
            sp.Panel2.BackColor = Bg;
        }
    }
}
