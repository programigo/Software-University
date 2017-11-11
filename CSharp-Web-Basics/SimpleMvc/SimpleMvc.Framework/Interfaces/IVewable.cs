namespace SimpleMvc.Framework.Interfaces
{
    public interface IVewable : IActionResult
    {
        IRenderable View { get; set; }
    }
}