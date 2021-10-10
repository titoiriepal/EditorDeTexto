﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;



public partial class Form1 : Form
{
    private Label etSaludo;
    private Button btSaludo;
    private ToolTip ttToolTip1;
    private delegate void SetColorDelegate(Color C);

    public Form1()
    {
        Iniciarcomponentes();
    }

    public void Iniciarcomponentes()
    {
        // Iniciar el formulario de la clase Form
        ClientSize = new Size(505, 285);
        Name = "Form1";
        Text = "Saludo";

        // Iniciar una etiqueta
        etSaludo = new Label();
        etSaludo.Name = "etSaludo";
        etSaludo.Text = "etiqueta";
        etSaludo.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
        etSaludo.TextAlign = ContentAlignment.MiddleCenter;
        etSaludo.Location = new Point(73, 77);
        etSaludo.Size = new Size(358, 40);
        etSaludo.TabIndex = 1;
        Controls.Add(etSaludo);

        //Iniciar un botón con su Tooltip
        btSaludo = new Button();
        btSaludo.Name = "btSaludo";
        btSaludo.Text = "Haga &clic aquí";
        btSaludo.Location = new Point(78, 176);
        btSaludo.Size = new Size(353, 36);
        btSaludo.TabIndex = 0;
        Controls.Add(btSaludo);
        ttToolTip1 = new ToolTip();
        ttToolTip1.SetToolTip(btSaludo, "Botón de pulsación");
        btSaludo.Click += new EventHandler(BtSaludo_Click);
    }
    protected override void Dispose(bool eliminar)
    {
        if (eliminar)
        {

        }
        base.Dispose(eliminar);
    }

    public static void Main()
    {
        Application.Run(new Form1());
    }

    private void BtSaludo_Click(object sender, EventArgs e)
    {
        etSaludo.Text = "¡¡¡Hola Mundo!!!";
        SetColorDelegate delegadoColor = new SetColorDelegate(SetColor_etSaludo);
        delegadoColor(Color.Red);
    }

    private void SetColor_etSaludo(Color color)
    {
        etSaludo.ForeColor = color;
    }

}