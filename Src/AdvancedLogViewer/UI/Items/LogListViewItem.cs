﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AdvancedLogViewer.Common.Parser;
using AdvancedLogViewer.BL.ColorHighlight;
using System.Drawing;

namespace AdvancedLogViewer.UI.Items
{
    class LogListViewItem:ListViewItem
    {
        public LogListViewItem(LogEntry logItem, ColorHighlightGroup colorHighlights)
        {
            this.LogItem = logItem;
            if (LogItem.Bookmark > 0)                  //0
                this.Text = "("+LogItem.Bookmark.ToString()+") "+ logItem.DateText;           
            else
                this.Text = logItem.DateText;          

            if (LogItem.Thread != null)
                this.SubItems.Add(LogItem.Thread);      //1
            if (LogItem.TypeStr != null)
                this.SubItems.Add(LogItem.TypeStr);        //2
            if (LogItem.Class != null)
                this.SubItems.Add(LogItem.Class);       //3

            this.SubItems.Add(logItem.Message);
            //this.SubItems.Add(logItem.Message.Substring(0, Math.Min(logItem.Message.Length, maxLengthOfMessage)));     //4             

            this.ImageIndex = (int)logItem.Type;

            if (colorHighlights != null)
            {
                Color color;
                Color textColor;
                if (colorHighlights.TryHighlightLogItem(logItem, out color, out textColor))
                {
                    this.BackColor = color;
                    this.ForeColor = textColor;
                }
            }
        }


        public LogEntry LogItem { get; private set; }
    }




}
