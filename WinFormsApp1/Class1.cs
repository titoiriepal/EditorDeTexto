using System;
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
        try
        {
            Rectangle restoreBounds = WinFormsApp1.Properties.Settings.Default.MainRestoreBounds;
            Left = restoreBounds.Left;
            Top = restoreBounds.Top;
            Width = restoreBounds.Width;
            Height = restoreBounds.Height;
            WindowState = WinFormsApp1.Properties.Settings.Default.MainWindowState;
        }
        catch
        {

        }

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
        if (this.WindowState == FormWindowState.Normal)
            WinFormsApp1.Properties.Settings.Default.MainRestoreBounds = this.DesktopBounds;
        else
            WinFormsApp1.Properties.Settings.Default.MainRestoreBounds = RestoreBounds;
        WinFormsApp1.Properties.Settings.Default.MainWindowState = WindowState;
        WinFormsApp1.Properties.Settings.Default.Save();
        if (eliminar)
        {

        }
        base.Dispose(eliminar);
    }

    public static void Main()
    {
        if (PrimeraInstancia)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        else
        {
            MessageBox.Show("La aplicación ya se está ejecutando");
            Application.Exit();
        }
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

    private static bool PrimeraInstancia
    {
        get
        {
            System.Threading.Mutex exmut;
            string nombre_exmut = "WinFormsApp1";
            bool nueva;
            exmut = new System.Threading.Mutex(true, nombre_exmut, out nueva);
            return nueva;
        }
    }

}