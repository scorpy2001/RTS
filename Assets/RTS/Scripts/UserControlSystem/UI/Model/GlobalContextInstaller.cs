using RTS.UserControlSystem.Model;
using RTS.UserControlSystem.UiModel;
using RTS.Utils;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GlobalContextInstaller", menuName = "Installers/GlobalContextInstaller")]
public class GlobalContextInstaller : ScriptableObjectInstaller<GlobalContextInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackTargetValue _attackTargetClicksRMB;
    [SerializeField] private SelectableValueModel _selectedObject;

    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _groundClicksRMB, _attackTargetClicksRMB, _selectedObject);
    }
}