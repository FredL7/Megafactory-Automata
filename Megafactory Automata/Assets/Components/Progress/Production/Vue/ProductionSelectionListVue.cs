using UnityEngine;

public class ProductionSelectionListVue : MonoBehaviour {
  [SerializeField] private ProdSelectSectionTitleVue sectionTitlePrefab;
  [SerializeField] private ProdSelectDistrictSingleVue districtSinglePrefab;
  [SerializeField] private ProdSelectDistrictEmptyVue districtEmptyPrefab;
  [SerializeField] private ProdSelectDistrictInfrastructureVue districtInfrastructurePrefab;
  [SerializeField] private ProdSelectInfrastructureVue infrastructurePrefab;

  [SerializeField] private RectTransform parent;

  private float sectionTitleHeight;
  private float districtSingleHeight;
  private float districtEmptyHeight;
  private float districtInfrastructureHeight;
  private float infrastructureHeight;

  void Awake() {
    sectionTitleHeight = ((RectTransform)sectionTitlePrefab.transform).sizeDelta.y;
    districtSingleHeight = ((RectTransform)districtSinglePrefab.transform).sizeDelta.y;
    districtEmptyHeight = ((RectTransform)districtEmptyPrefab.transform).sizeDelta.y;
    districtInfrastructureHeight = ((RectTransform)districtInfrastructurePrefab.transform).sizeDelta.y;
    infrastructureHeight = ((RectTransform)infrastructurePrefab.transform).sizeDelta.y;
  }

  public void Draw(ProductionManager manager) {
    SceneHelper.DestroyChildrenInParent(parent);

    float h = 0f;
    h = DrawDistrictAndBuildingList(manager, h);
    // TODO: DrawUnitList();
    //? DrawWonderList();
    //? Draw projects

    parent.sizeDelta = new Vector2(0, h);
  }

  private float DrawDistrictAndBuildingList(ProductionManager production, float h) {
    h = InstantiateSectionTitle("Districts & Buildings", h);

    ComplexBuilding[] districts = production.ComplexBuildingsWithHQ;
    for (int i = 0; i < districts.Length; ++i)
      h = InstantiateDistrict(districts[i], h, production);

    return h;
  }

  private float InstantiateSectionTitle(string title, float h) {
    ProdSelectSectionTitleVue instance = Instantiate(sectionTitlePrefab);
    instance.transform.position = new Vector3(0f, -h, 0f);
    instance.transform.SetParent(parent, false);
    instance.Write(title);

    return h + sectionTitleHeight;
  }

  private float InstantiateDistrict(ComplexBuilding district, float h, ProductionManager production) {
    if (!district.Built) {
      // Draw district as production item
      return InstantiateDistrictSingle(district, h, production);
    } else if (district.HasInfrastructureToBuild()) {
      // Draw district as wrapper for infrastructure production items
      return InstantiateDistrictInfrastructure(district, h, production);
    } else {
      // Draw district marked as completed
      return InstantiateDistrictEmpty(district, h);
    }
  }

  private float InstantiateDistrictSingle(ComplexBuilding district, float h, ProductionManager production) {
    ProdSelectDistrictSingleVue instance = Instantiate(districtSinglePrefab);
    instance.transform.position = new Vector3(0f, -h, 0f);
    instance.transform.SetParent(parent, false);
    instance.Write(district, production.GetProductionTime(district.ProductionCost), production);

    return h + districtSingleHeight;
  }

  private float InstantiateDistrictInfrastructure(ComplexBuilding district, float h, ProductionManager production) {
    ProdSelectDistrictInfrastructureVue instance = Instantiate(districtInfrastructurePrefab);
    instance.transform.position = new Vector3(0f, -h, 0f);
    instance.transform.SetParent(parent, false);
    instance.Write(district);

    float h2 = 0f;
    Infrastructure[] infrastructures = district.GetInfrastructureAvailForProd();
    for (int i = 0; i < infrastructures.Length; ++i)
      h2 = InstantiateInfrastructure(infrastructures[i], h2, instance, production);

    instance.SetHeight(districtInfrastructureHeight, h2);

    return h + districtInfrastructureHeight + h2;
  }

  private float InstantiateInfrastructure(
    Infrastructure infrastructure, float h,
    ProdSelectDistrictInfrastructureVue districtListItemVue,
    ProductionManager production
  ) {
    ProdSelectInfrastructureVue instance = Instantiate(infrastructurePrefab);
    instance.transform.position = new Vector3(0f, -h, 0f);
    instance.transform.SetParent(districtListItemVue.Parent, false);
    instance.Write(infrastructure, production.GetProductionTime(infrastructure.ProductionCost), production);

    return h + infrastructureHeight;
  }

  private float InstantiateDistrictEmpty(ComplexBuilding district, float h) {
    ProdSelectDistrictEmptyVue instance = Instantiate(districtEmptyPrefab);
    instance.transform.position = new Vector3(0f, -h, 0f);
    instance.transform.SetParent(parent, false);
    instance.Write(district);

    return h + districtEmptyHeight;
  }
}
