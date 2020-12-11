namespace ConsoleApp1
{
  
  public class PlayerInput
  {

    public delegate void OnKeyPressed();

    public event OnKeyPressed UpKeyPressed;
    public event OnKeyPressed DownKeyPressed;
    public event OnKeyPressed LeftKeyPressed;
    public event OnKeyPressed RightKeyPressed;

    public void InvokeUpKeyPressedEvent()
    {
      UpKeyPressed?.Invoke();
    }

    public void InvokeDownKeyPressedEvent()
    {
      DownKeyPressed?.Invoke();
    }

    public void InvokeLeftKeyPressedEvent()
    {
      LeftKeyPressed?.Invoke();
    }

    public void InvokeRightKeyPressedEvent()
    {
      RightKeyPressed?.Invoke();
    }

  }
  
}