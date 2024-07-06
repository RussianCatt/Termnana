namespace Termnana.Nanas
{
    public interface INana
    {
        string CommandName { get; }
        string Author { get; }
        string Version { get; }
        string Description { get; }
        bool RequiresArguments { get; }
        string PluginName { get; }
        string[] Dependencies { get; }
        void Execute(string[] args);
    }
}
