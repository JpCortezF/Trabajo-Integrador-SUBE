﻿namespace Sube
{
    partial class InicioPasajero
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            iNICIOToolStripMenuItem = new ToolStripMenuItem();
            vIAJARToolStripMenuItem = new ToolStripMenuItem();
            mISUBEToolStripMenuItem = new ToolStripMenuItem();
            subeToolStripMenuItem = new ToolStripMenuItem();
            viajesToolStripMenuItem = new ToolStripMenuItem();
            tarifaSocialToolStripMenuItem = new ToolStripMenuItem();
            darDeBajaToolStripMenuItem = new ToolStripMenuItem();
            mISTRÁMITESToolStripMenuItem = new ToolStripMenuItem();
            lblNombre = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { iNICIOToolStripMenuItem, vIAJARToolStripMenuItem, mISUBEToolStripMenuItem, mISTRÁMITESToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1000, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // iNICIOToolStripMenuItem
            // 
            iNICIOToolStripMenuItem.Name = "iNICIOToolStripMenuItem";
            iNICIOToolStripMenuItem.Size = new Size(117, 29);
            iNICIOToolStripMenuItem.Text = "| INICIO |";
            iNICIOToolStripMenuItem.Click += iNICIOToolStripMenuItem_Click;
            // 
            // vIAJARToolStripMenuItem
            // 
            vIAJARToolStripMenuItem.Name = "vIAJARToolStripMenuItem";
            vIAJARToolStripMenuItem.Size = new Size(129, 29);
            vIAJARToolStripMenuItem.Text = "| VIAJAR |";
            vIAJARToolStripMenuItem.Click += vIAJARToolStripMenuItem_Click;
            // 
            // mISUBEToolStripMenuItem
            // 
            mISUBEToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { subeToolStripMenuItem, viajesToolStripMenuItem, tarifaSocialToolStripMenuItem, darDeBajaToolStripMenuItem });
            mISUBEToolStripMenuItem.Name = "mISUBEToolStripMenuItem";
            mISUBEToolStripMenuItem.Size = new Size(143, 29);
            mISUBEToolStripMenuItem.Text = "| MI SUBE |";
            // 
            // subeToolStripMenuItem
            // 
            subeToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            subeToolStripMenuItem.Name = "subeToolStripMenuItem";
            subeToolStripMenuItem.Size = new Size(168, 24);
            subeToolStripMenuItem.Text = "Sube";
            subeToolStripMenuItem.Click += subeToolStripMenuItem_Click;
            // 
            // viajesToolStripMenuItem
            // 
            viajesToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            viajesToolStripMenuItem.Name = "viajesToolStripMenuItem";
            viajesToolStripMenuItem.Size = new Size(168, 24);
            viajesToolStripMenuItem.Text = "Viajes";
            viajesToolStripMenuItem.Click += viajesToolStripMenuItem_Click;
            // 
            // tarifaSocialToolStripMenuItem
            // 
            tarifaSocialToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            tarifaSocialToolStripMenuItem.Name = "tarifaSocialToolStripMenuItem";
            tarifaSocialToolStripMenuItem.Size = new Size(168, 24);
            tarifaSocialToolStripMenuItem.Text = "Tarifa Social";
            tarifaSocialToolStripMenuItem.Click += tarifaSocialToolStripMenuItem_Click;
            // 
            // darDeBajaToolStripMenuItem
            // 
            darDeBajaToolStripMenuItem.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            darDeBajaToolStripMenuItem.Name = "darDeBajaToolStripMenuItem";
            darDeBajaToolStripMenuItem.Size = new Size(168, 24);
            darDeBajaToolStripMenuItem.Text = "Dar de baja";
            darDeBajaToolStripMenuItem.Click += darDeBajaToolStripMenuItem_Click;
            // 
            // mISTRÁMITESToolStripMenuItem
            // 
            mISTRÁMITESToolStripMenuItem.Name = "mISTRÁMITESToolStripMenuItem";
            mISTRÁMITESToolStripMenuItem.Size = new Size(211, 29);
            mISTRÁMITESToolStripMenuItem.Text = "| MIS TRÁMITES |";
            mISTRÁMITESToolStripMenuItem.Click += mISTRÁMITESToolStripMenuItem_Click;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.ForeColor = Color.White;
            lblNombre.Location = new Point(260, 92);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(92, 31);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "¡Hola!";
            // 
            // InicioPasajero
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.headerShortMiSube;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1000, 550);
            ControlBox = false;
            Controls.Add(lblNombre);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "InicioPasajero";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InicioPasajero";
            Load += InicioPasajero_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mISUBEToolStripMenuItem;
        private ToolStripMenuItem viajesToolStripMenuItem;
        private ToolStripMenuItem tarifaSocialToolStripMenuItem;
        private ToolStripMenuItem subeToolStripMenuItem;
        private Label lblNombre;
        private ToolStripMenuItem vIAJARToolStripMenuItem;
        private ToolStripMenuItem iNICIOToolStripMenuItem;
        private ToolStripMenuItem darDeBajaToolStripMenuItem;
        private ToolStripMenuItem mISTRÁMITESToolStripMenuItem;
    }
}