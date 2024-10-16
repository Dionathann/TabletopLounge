using UnityEngine;

public interface IIcognitoRoleMechanism
{
    void DisplayRoles();
    Sprite IcognitoIconRandomizer();
    void PassListName();
    bool PlayerCheck();
    void RoleAssign();
}