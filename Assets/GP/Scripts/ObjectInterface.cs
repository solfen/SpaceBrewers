
interface ObjectInterface {

    void OnBuilded();
    void OnUpgraded();
    void OnRepaired();
    void OnBroken();
    void OnDestroyed();
    void OnUseBegin(Sailor sailor = null);
    void OnUseEnd();
}
