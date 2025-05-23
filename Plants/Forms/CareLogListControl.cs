﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Plants.Models;

namespace Plants.Forms
{
    public partial class CareLogListControl : UserControl, IComparer
    {
        private int sortColumn = -1;
        private SortOrder sortOrder = SortOrder.None;
        private List<CareLog> _currentLogs = new();

        public event Action<CareLog?>? CareLogSelected;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        private const int LVM_GETHEADER = 0x1000 + 31;

        public CareLogListControl()
        {
            InitializeComponent();

            listViewLogs.ColumnClick += ListViewLogs_ColumnClick;
            listViewLogs.OwnerDraw = true;
            listViewLogs.DrawColumnHeader += ListViewLogs_DrawColumnHeader;
            listViewLogs.DrawItem += (s, e) => e.DrawDefault = true;
            listViewLogs.DrawSubItem += (s, e) => e.DrawDefault = true;
            listViewLogs.SelectedIndexChanged += ListViewLogs_SelectedIndexChanged;
            listViewLogs.Resize += (s, e) => AutoResizeColumns();
        }

        private void ListViewLogs_DrawColumnHeader(object? sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawBackground();
            var font = e.Font ?? SystemFonts.DefaultFont;
            string headerText = e.Header?.Text ?? "----";

            e.Graphics.DrawString(headerText, font, Brushes.Black, e.Bounds.X + 4, e.Bounds.Y + 4);

            if (e.ColumnIndex == sortColumn)
            {
                string arrow = sortOrder == SortOrder.Ascending ? "▲" : "▼";
                var arrowFont = new Font("Arial", 8, FontStyle.Bold);
                var arrowSize = e.Graphics.MeasureString(arrow, arrowFont);

                e.Graphics.DrawString(arrow, arrowFont, Brushes.Black,
                    e.Bounds.Right - arrowSize.Width - 4, e.Bounds.Y + (e.Bounds.Height - arrowSize.Height) / 2);
            }

            using var pen = new Pen(SystemColors.ControlDark);
            e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
        }

        public void LoadLogs(List<CareLog> logs)
        {
            _currentLogs = logs;
            listViewLogs.Items.Clear();

            foreach (var log in logs)
            {
                var item = new ListViewItem(log.CareDate.ToString("g"));
                item.SubItems.Add(log.ActionDisplay ?? "----");
                item.SubItems.Add(string.IsNullOrWhiteSpace(log.Comment) ? "----" : log.Comment);
                item.SubItems.Add(log.TemperatureAtCare.ToString("F1"));
                item.SubItems.Add(log.HumidityAtCare.ToString("F0"));
                item.SubItems.Add(log.GrowthMeasurementCm.ToString("F1"));
                item.SubItems.Add(log.HealthStatus.ToString());
                item.SubItems.Add(string.IsNullOrWhiteSpace(log.ObservedProblems) ? "----" : log.ObservedProblems);

                listViewLogs.Items.Add(item);
            }

            AutoResizeColumns();
        }

        private void ListViewLogs_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listViewLogs.SelectedItems.Count > 0)
            {
                var index = listViewLogs.SelectedItems[0].Index;
                if (index >= 0 && index < _currentLogs.Count)
                {
                    CareLogSelected?.Invoke(_currentLogs[index]);
                    return;
                }
            }

            CareLogSelected?.Invoke(null);
        }

        private void ListViewLogs_ColumnClick(object? sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortColumn)
            {
                sortOrder = sortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                sortColumn = e.Column;
                sortOrder = SortOrder.Ascending;
            }

            listViewLogs.ListViewItemSorter = this;
            listViewLogs.Sort();
            ForceHeaderRedraw();
        }

        public int Compare(object? x, object? y)
        {
            if (sortColumn < 0) return 0;
            if (x is not ListViewItem itemX || y is not ListViewItem itemY) return 0;

            string a = itemX.SubItems.Count > sortColumn ? itemX.SubItems[sortColumn].Text : string.Empty;
            string b = itemY.SubItems.Count > sortColumn ? itemY.SubItems[sortColumn].Text : string.Empty;

            int result;
            if (sortColumn == 0 &&
                DateTime.TryParse(a, out var dateA) &&
                DateTime.TryParse(b, out var dateB))
            {
                result = dateA.CompareTo(dateB);
            }
            else
            {
                result = string.Compare(a, b, StringComparison.CurrentCulture);
            }

            return sortOrder == SortOrder.Ascending ? result : -result;
        }

        private void AutoResizeColumns()
        {
            if (listViewLogs.Columns.Count == 0) return;

            int totalWidth = listViewLogs.ClientSize.Width;
            int[] relativeWidths = { 12, 12, 24, 10, 10, 10, 10, 12 };

            int totalParts = 0;
            foreach (var part in relativeWidths)
                totalParts += part;

            int assignedWidth = 0;
            for (int i = 0; i < relativeWidths.Length; i++)
            {
                int width = (totalWidth * relativeWidths[i]) / totalParts;
                listViewLogs.Columns[i].Width = width;
                assignedWidth += width;
            }

            int extra = totalWidth - assignedWidth;
            if (extra > 0)
            {
                listViewLogs.Columns[^1].Width += extra;
            }
        }

        private void ForceHeaderRedraw()
        {
            IntPtr header = SendMessage(listViewLogs.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
            if (header != IntPtr.Zero)
            {
                InvalidateRect(header, IntPtr.Zero, true);
            }
        }
    }
}
