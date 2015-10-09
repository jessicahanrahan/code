using StructureMap.Graph;

namespace code.containers.structuremap.extensions
{
  public static class ScanningConventionExtensionsGateway
  {
    public static ScanningExtensionPoint enhanced(this IAssemblyScanner scanner)
    {
      return new ScanningExtensionPoint {scanner = scanner};
    }
  }
}