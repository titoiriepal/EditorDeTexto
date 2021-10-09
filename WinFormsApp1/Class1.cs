using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;



public partial class Form1 : Form
{
    private Label etSaludo;
    public Form1()
    {
        Iniciarcomponentes();
    }

    public void Iniciarcomponentes()
    {
        ClientSize = new Size(505, 285);
        Name = "Form1";
        Text = "Saludo";
        etSaludo = new Label();
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

}