using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Encrypt_DeCrypt_Program;

public partial class Form1 : Form
{
    private CancellationTokenSource? cts;
    int len = 0;
    Dictionary<string, List<string>>? passwords;

    public Form1()
    {
        InitializeComponent();
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        passwords = new Dictionary<string, List<string>>();
    }

    #region Methods

    #region KeyMethods
    bool passwordChecker()
    {
        foreach (KeyValuePair<string, List<string>> item in passwords!)
            if (item.Key == txt.Text)
                foreach (var i in item.Value)
                    if (i == key.Text)
                        return false;

        return true;
    }

    void passwordAdder()
    {
        foreach (var item in passwords!)
            if (item.Key == txt.Text)
            {
                item.Value.Add(key.Text);
                return;
            }

        passwords.Add(txt.Text, new List<string>() { key.Text });
    }

    bool passwordDeleter(string key)
    {
        foreach (var item in passwords!)
            if (item.Key == txt.Text)
                if (item.Value.Count > 0)
                    foreach (var value in item.Value)
                        if (key == value)
                            return item.Value.Remove(value);
        return false;
    }
    #endregion

    #region Token_Encrypt_Decrypt_Methods
    private bool EncryptFile(CancellationToken token)
    {
        using (FileStream s = new FileStream(txt.Text, FileMode.Open))
        {
            len = (int)s.Length;
            byte readByte;
            int index = 0;
            byte[] byteKey;

            byteKey = Encoding.UTF8.GetBytes(key.Text);

            progressBar1.Invoke(() =>
            {
                progressBar1.Maximum = len;
            });

            for (int i = 0; i < len; i++)
            {
                Thread.Sleep(500);
                if (token.IsCancellationRequested)
                {
                    for (int k = i - 1; k >= 0; k--)
                    {
                        Thread.Sleep(500);

                        s.Position = k;
                        readByte = (byte)s.ReadByte();
                        s.Position = k;

                        if (--index == -1)
                            index = key.Text.Length - 1;

                        readByte ^= byteKey[index];
                        progressBar1.Invoke(() =>
                        {
                            progressBar1.Value = k;
                            label1.Text = (k * 100 / len).ToString() + " %";
                        });

                        s.WriteByte(readByte);
                    }

                    key.Invoke(() =>
                    {
                        key.Enabled = true;
                        checkBox1.Enabled = true;
                        checkBox2.Enabled = true;
                        StartBtn.Enabled = true;
                        FileBtn.Enabled = true;
                        CancelBtn.Enabled = false;
                    });

                    passwordDeleter(key.Text);

                    MessageBox.Show("Encrypted was cancelled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return false;
                }

                readByte = (byte)s.ReadByte();
                readByte ^= byteKey[index++];

                progressBar1.Invoke(() =>
                {
                    progressBar1.Value = i + 1;
                    label1.Text = ((i + 1) * 100 / len).ToString() + " %";
                });

                s.Position = i;
                s.WriteByte(readByte);

                if (index == byteKey.Length)
                    index = 0;
            }

            return true;
        }
    }
    private CancellationToken token()
    {
        cts = new CancellationTokenSource();
        return cts.Token;
    }
    private async void EncryptBtnMethodAsync()
    {
        key.Enabled = false;
        checkBox1.Enabled = false;
        checkBox2.Enabled = false;
        StartBtn.Enabled = false;
        FileBtn.Enabled = false;
        CancelBtn.Enabled = true;

        progressBar1.Value = 0;
        label1.Text = "0 %";

        passwordAdder();

        bool flag = await Task.Run(() => EncryptFile(token()));

        key.Enabled = true;
        checkBox1.Enabled = true;
        checkBox2.Enabled = true;
        StartBtn.Enabled = true;
        FileBtn.Enabled = true;
        CancelBtn.Enabled = false;

        if (flag)
            MessageBox.Show("Encrypted was completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        progressBar1.Value = 0;
        label1.Text = "0 %";
    }
    private async void DecryptBtnMethodAsync()
    {
        key.Enabled = false;
        checkBox1.Enabled = false;
        checkBox2.Enabled = false;
        StartBtn.Enabled = false;
        FileBtn.Enabled = false;
        CancelBtn.Enabled = false;

        progressBar1.Value = 0;
        label1.Text = "0 %";

        bool flag = await Task.Run(() => EncryptFile(token()));

        passwordDeleter(key.Text);

        if (flag)
            MessageBox.Show("Decrypted was completed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        progressBar1.Value = 0;
        label1.Text = "0 %";

        key.Enabled = true;
        checkBox1.Enabled = true;
        checkBox2.Enabled = true;
        StartBtn.Enabled = true;
        FileBtn.Enabled = true;
    }
    #endregion

    #region Another_Methods
    void openFile()
    {
        OpenFileDialog dlg = new OpenFileDialog();
        dlg.DefaultExt = ".txt";
        dlg.Filter = "Text documents (.txt)|*.txt";

        if (dlg.ShowDialog() == DialogResult.OK)
            txt.Text = dlg.FileName;

        if (txt.Text != string.Empty)
        {
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
        }
    }
    #endregion

    #endregion

    private void Btn_Click(object sender, EventArgs e)
    {
        var btn = sender as Button;

        if (btn == FileBtn)
            openFile();
        else if (btn == StartBtn)
        {
            if (checkBox1.Checked)
            {
                if (key.Text != string.Empty)
                {
                    if (passwordChecker())
                        EncryptBtnMethodAsync();
                    else
                        MessageBox.Show("This password was used", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (checkBox2.Checked)
            {
                if (key.Text != string.Empty)
                {
                    if (!passwordChecker())
                        DecryptBtnMethodAsync();
                    else
                        MessageBox.Show("False password to decrypted...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        else if (btn == CancelBtn)
            if (cts != null)
            {
                cts.Cancel();
                cts.Dispose();
            }
    }

    private void CheckedChanged(object sender, EventArgs e)
    {
        var check = sender as CheckBox;

        if (check == checkBox1)
            if (checkBox1.Checked == true)
                checkBox2.Checked = false;
        if (check == checkBox2)
            if (checkBox2.Checked == true)
                checkBox1.Checked = false;

        key.Enabled = true;
        StartBtn.Enabled = true;
    }
}