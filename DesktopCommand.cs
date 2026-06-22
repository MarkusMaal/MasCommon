using System.Text.Json;
using System.Text.Json.Serialization;

namespace MasCommon;

public class DesktopCommand
{
    /// <summary>
    /// Specify what kind of command you want to send to desktop app
    /// </summary>
    public required string Type { get; set; }
    
    /// <summary>
    /// Specific arguments for the command you send
    /// </summary>
    public required string Arguments { get; set; }

    /// <summary>
    /// Replaces current configuration
    /// </summary>
    /// <param name="mas_root">Root directory for Markus' stuff system. Usually %UserProfile\.mas.</param>
    public void Load(string mas_root)
    {
        var cnf = JsonSerializer.Deserialize(File.ReadAllText(mas_root + "/DesktopIconsCommand.json"), CommandSourceGenerationContext.Default.DesktopCommand);
        this.Type = cnf?.Type ?? "";
        this.Arguments = cnf?.Arguments ?? "";
    }

    /// <summary>
    /// Saves current configuration
    /// </summary>
    /// <param name="mas_root">Root directory for Markus' stuff system. Usually %UserProfile\.mas.</param>
    public void Send(string mas_root)
    {
        var jsonData = JsonSerializer.Serialize(this, CommandSourceGenerationContext.Default.DesktopCommand);
        File.WriteAllText(mas_root + "/DesktopIconsCommand.json", jsonData);
    }
}

// Required for generating trimmed executables
[JsonSerializable(typeof(DesktopCommand))]
[JsonSerializable(typeof(string))]
public partial class CommandSourceGenerationContext : JsonSerializerContext
{
}