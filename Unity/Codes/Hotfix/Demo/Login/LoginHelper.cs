using System;


namespace ET
{
    [FriendClass(typeof(ServerInfosComponent))]
    [FriendClass(typeof(RoleInfosComponent))]
    [FriendClass(typeof(AccountInfoComponent))]
    public static class LoginHelper
    {
        public static async ETTask<int> Login(Scene zoneScene, string address, string account, string password)
        {
            A2C_LoginAccount a2C_LoginAccount = null;
            Session accountSession = null;

            try
            {
                accountSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                password = MD5Helper.StringMD5(password);
                a2C_LoginAccount = (A2C_LoginAccount) await accountSession.Call(new C2A_LoginAccount() { AccountName = account , Password = password}) ;
            }
            catch (Exception e)
            {
                Log.Error(e);
                accountSession?.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2C_LoginAccount.Error != ErrorCode.ERR_Success)
            {
                accountSession?.Dispose();
                return a2C_LoginAccount.Error;
            }

            zoneScene.AddComponent<SessionComponent>().Session = accountSession;

            // 心跳检测
            zoneScene.GetComponent<SessionComponent>().Session.AddComponent<PingComponent>();

            zoneScene.GetComponent<AccountInfoComponent>().Token = a2C_LoginAccount.Token;
            zoneScene.GetComponent<AccountInfoComponent>().AccountId = a2C_LoginAccount.AccountId; 
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetServerInfos(Scene zoneScene)
        {
            A2C_GetServerInfos a2CGetServerInfos = null;
            try
            {
                a2CGetServerInfos = (A2C_GetServerInfos)await zoneScene.GetComponent<SessionComponent>().
                        Session.Call(new C2A_GetServerInfos()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token
                });
            }
            catch(Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2CGetServerInfos.Error != ErrorCode.ERR_Success)
                return a2CGetServerInfos.Error;


            foreach (var serverInfoProto in a2CGetServerInfos.ServerInfosList)
            {
                var serverInfo = zoneScene.GetComponent<ServerInfosComponent>().AddChild<ServerInfo>();
                serverInfo.FromMessage(serverInfoProto);
                zoneScene.GetComponent<ServerInfosComponent>().Add(serverInfo);
            }

            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> CreateRole(Scene zoneScene, string name)
        {
            A2C_CreateRole a2CCreateRole = null;

            try
            {
                a2CCreateRole = (A2C_CreateRole)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_CreateRole()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    Name = name,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId
                }); ;;
            }
            catch(Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2CCreateRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2CCreateRole.Error.ToString());
                return a2CCreateRole.Error;
            }

            var newRoleInfos = zoneScene.GetComponent<RoleInfosComponent>().AddChild<RoleInfo>();
            newRoleInfos.FromMessage(a2CCreateRole.RoleInfo);
            zoneScene.GetComponent<RoleInfosComponent>().List_RoleInfos.Add(newRoleInfos);

            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetRoles(Scene zoneScene)
        {
            A2C_GetRoles a2C_GetRoles = null;

            try
            {
                a2C_GetRoles = (A2C_GetRoles)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRoles()
                {
                    Account = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                });
            }
            catch(Exception e) 
            {
                Log.Error(e.ToString() + "获取角色失败");
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2C_GetRoles.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2C_GetRoles.Error.ToString() + "获取角色失败");
                return a2C_GetRoles.Error;
            }

            zoneScene.GetComponent<RoleInfosComponent>().List_RoleInfos.Clear();
            foreach (var roleInfoProto in a2C_GetRoles.RoleInfo)
            {
                var roleInfo = zoneScene.GetComponent<RoleInfosComponent>().AddChild<RoleInfo>();
                roleInfo.FromMessage(roleInfoProto);
                zoneScene.GetComponent<RoleInfosComponent>().List_RoleInfos.Add(roleInfo);
            }

            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> DeleteRole(Scene zoneScene)
        {
            A2C_DeleteRole a2cDeleteRole = null;

            try
            {
                a2cDeleteRole = (A2C_DeleteRole)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_DeleteRole()
                {
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    RoleInfoId = zoneScene.GetComponent<RoleInfosComponent>().CurrentRoleId,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                }); ;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2cDeleteRole.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2cDeleteRole.Error.ToString());
                return a2cDeleteRole.Error;
            }

            var index = zoneScene.GetComponent<RoleInfosComponent>().List_RoleInfos.FindIndex((info) =>
            {
                return info.Id == a2cDeleteRole.DeletedRoleInfoId;
            });

            zoneScene.GetComponent<RoleInfosComponent>().List_RoleInfos.RemoveAt(index);
            
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> GetRelamKey(Scene zoneScene)
        {
            A2C_GetRealmKey a2C_GetRealmKey = null;

            try
            {
                a2C_GetRealmKey = (A2C_GetRealmKey)await zoneScene.GetComponent<SessionComponent>().Session.Call(new C2A_GetRealmKey()
                {
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurrentServerId,
                });
            }
            catch(Exception e)
            {
                Log.Error(e.ToString());
                return a2C_GetRealmKey.Error;
            }

            if (a2C_GetRealmKey.Error != ErrorCode.ERR_Success)
            {
                Log.Error(a2C_GetRealmKey.Error.ToString());
                return a2C_GetRealmKey.Error;
            }

            zoneScene.GetComponent<AccountInfoComponent>().RealmKey = a2C_GetRealmKey.Realmkey;
            zoneScene.GetComponent<AccountInfoComponent>().RealmAddress = a2C_GetRealmKey.RealmAddress;
            // 断开客户端和账号服的链接
            zoneScene.GetComponent<SessionComponent>().Session.Dispose();
            await ETTask.CompletedTask;
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> EnterGame(Scene zoneScene)
        {
            var realmAddress = zoneScene.GetComponent<AccountInfoComponent>().RealmAddress;
            R2C_LoginRealm r2C_LoginRealm = null;

            // 使用realm的地址创建一个session
            var session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(realmAddress));

            try
            {
                r2C_LoginRealm = (R2C_LoginRealm)await session.Call(new C2R_LoginRealm()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    RealmTokenKey = zoneScene.GetComponent<AccountInfoComponent>().RealmKey
                });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                session?.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }

            // 跟网关均衡服务器断开
            session?.Dispose();
            if (r2C_LoginRealm.Error != ErrorCode.ERR_Success)
            {
                Log.Error(r2C_LoginRealm.Error.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            Log.Warning($"GateAddress : {r2C_LoginRealm.GateAddress}");

            // 连接Gate
            // 创建Session
            var gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2C_LoginRealm.GateAddress));
            gateSession.AddComponent<PingComponent>();
            zoneScene.GetComponent<SessionComponent>().Session = gateSession;
            var currentRoleId = zoneScene.GetComponent<RoleInfosComponent>().CurrentRoleId;
            G2C_LoginGameGate g2C_LoginGameGate = null;
            try
            {
                var accountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId;
                g2C_LoginGameGate = (G2C_LoginGameGate)await gateSession.Call(new C2G_LoginGameGate()
                {
                    Key = r2C_LoginRealm.GateSessionKey,
                    Account = accountId,
                    RoleId = currentRoleId,
                });
            }
            catch(Exception e)
            {
                Log.Error("登陆gate失败" + e.ToString());
                zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }

            if (g2C_LoginGameGate.Error != ErrorCode.ERR_Success)
            {
                Log.Debug("登陆gate失败");
                zoneScene.GetComponent<SessionComponent>().Session.Dispose();
                return g2C_LoginGameGate.Error;
            }

            Log.Debug("登陆gate成功");

            // 连接逻辑服
            G2C_EnterGame g2C_EnterGame = null;
            try
            {
                g2C_EnterGame = (G2C_EnterGame) await gateSession.Call(new C2G_EnterGame()
                {

                });
            }
            catch (Exception e)
            {
                Log.Error("登陆游戏服失败" + e);
                zoneScene.GetComponent<SessionComponent>().Session.Dispose(); 
                return ErrorCode.ERR_NetWorkError;
            }

            if (g2C_EnterGame.Error != ErrorCode.ERR_Success)
            {
                Log.Error(g2C_EnterGame.Error.ToString());
                return g2C_EnterGame.Error;
            }

            Log.Debug("角色进入游戏成功");
            zoneScene.GetComponent<PlayerComponent>().MyId = g2C_EnterGame.MyId;
            await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_SceneChangeFinish>();
            return ErrorCode.ERR_Success;
        }
    }
}