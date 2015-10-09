using developwithpassion.specification.adapters.rhino_mocks;
using developwithpassion.specifications.assertions;
using developwithpassion.specifications.should;
using Machine.Specifications;
using StructureMap.Graph;

namespace code.containers.structuremap.extensions
{  
  [Subject(typeof(ScanningConventionExtensionsGateway))]  
  public class ScanningExtensionPointGatewaySpecs
  {
    public abstract class concern : spec
    {
        
    }
   
    public class when_providing_access_to_enhanced_structure_map_assembly_scanning_capabilities : concern
    {
      Establish c = () =>
      {
        scanner = fake.an<IAssemblyScanner>();
      };

      Because b = () =>
        result = scanner.enhanced();

      It returns_an_assemlby_scanning_extension_point_initialized_with_the_assembly_scanner = () =>
      {
        var extension = result.should().be_an<ScanningExtensionPoint>();
        extension.get_value().scanner.ShouldEqual(scanner);
      };

      static ScanningExtensionPoint result;
      static IAssemblyScanner scanner;
    }
  }
}
