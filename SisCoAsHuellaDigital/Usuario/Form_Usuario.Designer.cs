namespace MicroSisPlani.Usuario
{
    partial class Form_Usuario
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Usuario));
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Pic_User = new System.Windows.Forms.PictureBox();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_cancelar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btn_aceptar = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Contraseña = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_Usuario = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_nombres = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.cbo_rol = new System.Windows.Forms.ComboBox();
            this.lbl_IdAsis = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).BeginInit();
            this.pnl_titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.Location = new System.Drawing.Point(66, 338);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 24);
            this.label11.TabIndex = 71;
            this.toolTip1.SetToolTip(this.label11, "Rol del Personal");
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Image = ((System.Drawing.Image)(resources.GetObject("label10.Image")));
            this.label10.Location = new System.Drawing.Point(66, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 24);
            this.label10.TabIndex = 70;
            this.toolTip1.SetToolTip(this.label10, "Usuario");
            // 
            // Pic_User
            // 
            this.Pic_User.Image = global::MicroSisPlani.Properties.Resources.usuario;
            this.Pic_User.Location = new System.Drawing.Point(477, 170);
            this.Pic_User.Name = "Pic_User";
            this.Pic_User.Size = new System.Drawing.Size(167, 169);
            this.Pic_User.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pic_User.TabIndex = 68;
            this.Pic_User.TabStop = false;
            this.Pic_User.Click += new System.EventHandler(this.Pic_persona_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.FlatAppearance.BorderSize = 0;
            this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir.ForeColor = System.Drawing.Color.White;
            this.btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_Salir.Image")));
            this.btn_Salir.Location = new System.Drawing.Point(663, 9);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(32, 32);
            this.btn_Salir.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btn_Salir, "Salir / Cerrar Ventana");
            this.btn_Salir.UseVisualStyleBackColor = true;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancelar.BackgroundStyle.SolidColor = System.Drawing.Color.WhiteSmoke;
            this.btn_cancelar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_cancelar.BorderStyle.SolidColor = System.Drawing.Color.DimGray;
            this.btn_cancelar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_cancelar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_cancelar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancelar.Location = new System.Drawing.Point(94, 460);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(239, 49);
            this.btn_cancelar.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.White;
            this.btn_cancelar.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.White;
            this.btn_cancelar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.White;
            this.btn_cancelar.StateStyles.HoverStyle.BorderGradientEndColor = System.Drawing.Color.White;
            this.btn_cancelar.StateStyles.HoverStyle.BorderGradientStartColor = System.Drawing.Color.White;
            this.btn_cancelar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.DimGray;
            this.btn_cancelar.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.TabIndex = 73;
            this.btn_cancelar.TextStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancelar.TextStyle.ForeColor = System.Drawing.Color.DimGray;
            this.btn_cancelar.TextStyle.Text = "Cancelar";
            this.btn_cancelar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancelar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.BackgroundStyle.SolidColor = System.Drawing.Color.DimGray;
            this.btn_aceptar.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.btn_aceptar.BorderStyle.SolidColor = System.Drawing.Color.DimGray;
            this.btn_aceptar.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btn_aceptar.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btn_aceptar.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.Location = new System.Drawing.Point(369, 460);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(239, 49);
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundGradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.StateStyles.HoverStyle.BackgroundSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.StateStyles.HoverStyle.BorderGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.StateStyles.HoverStyle.BorderGradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.StateStyles.HoverStyle.BorderSolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_aceptar.StateStyles.HoverStyle.TextFont = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.TabIndex = 69;
            this.btn_aceptar.TextStyle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aceptar.TextStyle.ForeColor = System.Drawing.Color.White;
            this.btn_aceptar.TextStyle.Text = "Listo";
            this.btn_aceptar.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // pnl_titulo
            // 
            this.pnl_titulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnl_titulo.Controls.Add(this.label7);
            this.pnl_titulo.Controls.Add(this.btn_Salir);
            this.pnl_titulo.Controls.Add(this.label1);
            this.pnl_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titulo.Location = new System.Drawing.Point(0, 0);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(707, 50);
            this.pnl_titulo.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(6, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "REGISTRO DE USUARIO";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(707, 2);
            this.label1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(66, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 24);
            this.label8.TabIndex = 65;
            this.toolTip1.SetToolTip(this.label8, "Contraseña");
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(66, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 24);
            this.label3.TabIndex = 60;
            this.toolTip1.SetToolTip(this.label3, "Nombre Completo");
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.Location = new System.Drawing.Point(66, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 24);
            this.label6.TabIndex = 64;
            this.toolTip1.SetToolTip(this.label6, "Nro de ID");
            // 
            // txt_Contraseña
            // 
            this.txt_Contraseña.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Contraseña.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Contraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Contraseña.HintForeColor = System.Drawing.Color.DarkGray;
            this.txt_Contraseña.HintText = "Password";
            this.txt_Contraseña.isPassword = true;
            this.txt_Contraseña.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_Contraseña.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_Contraseña.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_Contraseña.LineThickness = 2;
            this.txt_Contraseña.Location = new System.Drawing.Point(110, 261);
            this.txt_Contraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Contraseña.Name = "txt_Contraseña";
            this.txt_Contraseña.Size = new System.Drawing.Size(294, 32);
            this.txt_Contraseña.TabIndex = 52;
            this.txt_Contraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Usuario.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Usuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Usuario.HintForeColor = System.Drawing.Color.DarkGray;
            this.txt_Usuario.HintText = "Usuario";
            this.txt_Usuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Usuario.isPassword = false;
            this.txt_Usuario.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_Usuario.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_Usuario.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_Usuario.LineThickness = 2;
            this.txt_Usuario.Location = new System.Drawing.Point(110, 195);
            this.txt_Usuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(294, 32);
            this.txt_Usuario.TabIndex = 51;
            this.txt_Usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_nombres
            // 
            this.txt_nombres.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_nombres.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_nombres.HintForeColor = System.Drawing.Color.DarkGray;
            this.txt_nombres.HintText = "Nombre Completo";
            this.txt_nombres.isPassword = false;
            this.txt_nombres.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_nombres.LineIdleColor = System.Drawing.Color.Gray;
            this.txt_nombres.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txt_nombres.LineThickness = 2;
            this.txt_nombres.Location = new System.Drawing.Point(110, 121);
            this.txt_nombres.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_nombres.Name = "txt_nombres";
            this.txt_nombres.Size = new System.Drawing.Size(438, 32);
            this.txt_nombres.TabIndex = 50;
            this.txt_nombres.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // cbo_rol
            // 
            this.cbo_rol.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_rol.ForeColor = System.Drawing.Color.DimGray;
            this.cbo_rol.FormattingEnabled = true;
            this.cbo_rol.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cbo_rol.Location = new System.Drawing.Point(110, 335);
            this.cbo_rol.Name = "cbo_rol";
            this.cbo_rol.Size = new System.Drawing.Size(201, 28);
            this.cbo_rol.TabIndex = 55;
            this.cbo_rol.SelectedIndexChanged += new System.EventHandler(this.cbo_rol_SelectedIndexChanged);
            // 
            // lbl_IdAsis
            // 
            this.lbl_IdAsis.AutoSize = true;
            this.lbl_IdAsis.Location = new System.Drawing.Point(107, 68);
            this.lbl_IdAsis.Name = "lbl_IdAsis";
            this.lbl_IdAsis.Size = new System.Drawing.Size(55, 13);
            this.lbl_IdAsis.TabIndex = 74;
            this.lbl_IdAsis.Text = "00000000";
            this.lbl_IdAsis.Visible = false;
            // 
            // Form_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(707, 568);
            this.Controls.Add(this.lbl_IdAsis);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Pic_User);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.pnl_titulo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbo_rol);
            this.Controls.Add(this.txt_Contraseña);
            this.Controls.Add(this.txt_Usuario);
            this.Controls.Add(this.txt_nombres);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Usuario";
            this.Load += new System.EventHandler(this.Form_Usuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_aceptar)).EndInit();
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox Pic_User;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public Klik.Windows.Forms.v1.EntryLib.ELButton btn_cancelar;
        public Klik.Windows.Forms.v1.EntryLib.ELButton btn_aceptar;
        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_Contraseña;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_Usuario;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txt_nombres;
        private System.Windows.Forms.ComboBox cbo_rol;
        internal System.Windows.Forms.Label lbl_IdAsis;
        private System.Windows.Forms.Label label6;
    }
}