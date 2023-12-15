namespace Modules.Gameplay
{
    public interface IInteractable
    {
        bool IsActive { get; }
        void Interact();
        
    }
}