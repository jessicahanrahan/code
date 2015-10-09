namespace code.containers
{
  public interface IRegisterDependencies
  {
    void register<Contract, Implementation>();

    void register<Contract>(Contract implementation);
  }
}