namespace DatabaseRestore;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
    }

    private void BtnBrowse_Click(object? sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        {
            txtFilePath.Text = openFileDialog.FileName;
            txtOutput.Clear();
        }
    }

    private async void BtnRestore_Click(object? sender, EventArgs e)
    {
        if (!ValidateInputs(out var filePath))
        {
            return;
        }

        btnRestore.Enabled = false;
        txtOutput.Clear();
        AppendLog("Convertendo caminho do arquivo para WSL...");

        try
        {
            var wslFilePath = ConvertToWslPath(filePath);
            AppendLog($"Arquivo no WSL: {wslFilePath}");
            AppendLog("Iniciando restore no MySQL...");

            var command = BuildRestoreCommand(wslFilePath, filePath);
            var result = await RunProcessAsync("wsl.exe", ["bash", "-lc", command]);

            if (!string.IsNullOrWhiteSpace(result.Output))
            {
                AppendLog(result.Output.Trim());
            }

            if (!string.IsNullOrWhiteSpace(result.Error))
            {
                AppendLog(result.Error.Trim());
            }

            AppendLog(result.ExitCode == 0
                ? "Restore concluido com sucesso."
                : $"Restore finalizado com erro. Codigo: {result.ExitCode}");
        }
        catch (Exception ex)
        {
            AppendLog($"Erro: {ex.Message}");
        }
        finally
        {
            btnRestore.Enabled = true;
        }
    }

    private bool ValidateInputs(out string filePath)
    {
        filePath = txtFilePath.Text.Trim();

        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            MessageBox.Show(this, "Selecione um arquivo .sql ou .gz valido.", "Arquivo obrigatorio",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        var extension = Path.GetExtension(filePath);
        if (!extension.Equals(".sql", StringComparison.OrdinalIgnoreCase)
            && !extension.Equals(".gz", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show(this, "O arquivo precisa ter extensao .sql ou .gz.", "Formato invalido",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtDatabase.Text))
        {
            MessageBox.Show(this, "Informe a base de dados MySQL.", "Base obrigatoria",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtUser.Text))
        {
            MessageBox.Show(this, "Informe o usuario MySQL.", "Usuario obrigatorio",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtHost.Text))
        {
            MessageBox.Show(this, "Informe o host MySQL.", "Host obrigatorio",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private static string ConvertToWslPath(string filePath)
    {
        var fullPath = Path.GetFullPath(filePath);
        var root = Path.GetPathRoot(fullPath);

        if (string.IsNullOrWhiteSpace(root) || root.StartsWith(@"\\", StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Use um arquivo em uma unidade local do Windows, como C: ou E:.");
        }

        var drive = char.ToLowerInvariant(root[0]);
        var relativePath = fullPath[root.Length..].Replace('\\', '/');

        return $"/mnt/{drive}/{relativePath}";
    }

    private string BuildRestoreCommand(string wslFilePath, string originalFilePath)
    {
        var file = BashQuote(wslFilePath);
        var host = BashQuote(txtHost.Text.Trim());
        var port = BashQuote(numPort.Value.ToString());
        var user = BashQuote(txtUser.Text.Trim());
        var password = BashQuote(txtPassword.Text);
        var database = BashQuote(txtDatabase.Text.Trim());

        var mysql = $"mysql --host={host} --port={port} --user={user} --password={password} {database}";

        return Path.GetExtension(originalFilePath).Equals(".gz", StringComparison.OrdinalIgnoreCase)
            ? $"gzip -dc -- {file} | {mysql}"
            : $"{mysql} < {file}";
    }

    private static string BashQuote(string value)
    {
        return $"'{value.Replace("'", "'\"'\"'")}'";
    }

    private async Task<ProcessResult> RunProcessAsync(string fileName, IReadOnlyList<string> arguments)
    {
        var startInfo = new System.Diagnostics.ProcessStartInfo
        {
            FileName = fileName,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        foreach (var argument in arguments)
        {
            startInfo.ArgumentList.Add(argument);
        }

        using var process = System.Diagnostics.Process.Start(startInfo)
            ?? throw new InvalidOperationException($"Nao foi possivel iniciar {fileName}.");

        var outputTask = process.StandardOutput.ReadToEndAsync();
        var errorTask = process.StandardError.ReadToEndAsync();

        await process.WaitForExitAsync();

        return new ProcessResult(
            process.ExitCode,
            await outputTask,
            await errorTask);
    }

    private void AppendLog(string message)
    {
        txtOutput.AppendText(message + Environment.NewLine);
    }

    private sealed record ProcessResult(int ExitCode, string Output, string Error);
}
