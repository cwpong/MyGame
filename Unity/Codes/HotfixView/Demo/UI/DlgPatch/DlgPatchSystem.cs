namespace ET
{
	[FriendClass(typeof(DlgPatch))]
	public static class DlgPatchSystem
	{

        public static void RegisterUIEvent(this DlgPatch self)
		{
			//self.View.EButton_ConfirmButton.AddListener(()=>
			//{
			//	BeginDownPatch();
   //         });

			//self.View.EButton_CancelButton.AddListener(() => 
			//{
			//	// TODO 退出游戏
			//});
		}

		public static void ShowWindow(this DlgPatch self, Entity contextData = null)
		{
            UnityEngine.Debug.LogWarning("开始下载");
            //BeginDownPatch();
            UnityEngine.Debug.LogWarning("下载结束");
        }

        /*
        private static IEnumerator BeginDownPatch()
        {

            // 初始化资源系统
            UnityEngine.Debug.LogWarning("初始化1");
            YooAssets.Initialize();
            UnityEngine.Debug.LogWarning("初始化2");
            YooAssets.SetOperationSystemMaxTimeSlice(30);

            // 设置该资源包为默认的资源包, 可以使用YooAssets相关加载接口该资源包内容
            var package = YooAssets.CreateAssetsPackage("DefaultPackage");
            YooAssets.SetDefaultAssetsPackage(package);
            UnityEngine.Debug.LogWarning($"获取资源版本成功 name = {package.PackageName}");
            // 编辑器模式
            if (MODEL == EPlayMode.EditorSimulateMode)
            {
                var initParameters = new EditorSimulateModeParameters();
                initParameters.SimulatePatchManifestPath = EditorSimulateModeHelper.SimulateBuild("DefaultPackage");
                yield return package.InitializeAsync(initParameters);

            }
            else if (MODEL == EPlayMode.OfflinePlayMode)
            {
                var initParameters = new OfflinePlayModeParameters();
                yield return package.InitializeAsync(initParameters);

            }
            else if (MODEL == EPlayMode.HostPlayMode)
            {
                UnityEngine.Debug.LogWarning("离线下载");
                var initParameters = new HostPlayModeParameters();
                initParameters.QueryServices = new QueryStreamingAssetsFileServices();
                initParameters.DefaultHostServer = "http://192.168.31.236:8080/CDN//v1.0.7";
                initParameters.FallbackHostServer = "http://192.168.31.236:8080/CDN/V1.0.7";
                yield return package.InitializeAsync(initParameters);
            }


            UnityEngine.Debug.LogWarning($"package Name = {package.PackageName}");
            // 获取资源版本
            var operation = package.UpdatePackageVersionAsync();
            yield return operation;


            UnityEngine.Debug.LogWarning($"EOperationStatus {operation.Status}");
            if (operation.Status != EOperationStatus.Succeed)
            {
                //更新失败
                UnityEngine.Debug.LogError(operation.Error);
                yield break;
            }

            string packageVersion = operation.PackageVersion;
            UnityEngine.Debug.Log($"Updated package Version : {packageVersion}");
            // 更新补丁清单
            var updateMainfest = package.UpdatePackageManifestAsync(packageVersion);
            yield return updateMainfest;

            if (operation.Status != EOperationStatus.Succeed)
            {
                UnityEngine.Debug.LogError(operation.Error);
                yield break;
            }

            UnityEngine.Debug.LogWarning("更新补丁清单本成功");
            // 下载补丁包
            yield return Download();
        }



        private static IEnumerator Download()
        {
            int downloadingMaxNum = 10;
            int failedTryAgain = 3;
            int timeout = 60;
            var package = YooAssets.GetAssetsPackage("DefaultPackage");
            var downloader = package.CreatePatchDownloader(downloadingMaxNum, failedTryAgain, timeout);

            //没有需要下载的资源
            if (downloader.TotalDownloadCount == 0)
            {
                yield break;
            }

            //需要下载的文件总数和总大小
            int totalDownloadCount = downloader.TotalDownloadCount;
            long totalDownloadBytes = downloader.TotalDownloadBytes;

            //注册回调方法
            downloader.OnDownloadErrorCallback = OnDownloadErrorFunction;
            downloader.OnDownloadProgressCallback = OnDownloadProgressUpdateFunction;
            downloader.OnDownloadOverCallback = OnDownloadOverFunction;
            downloader.OnStartDownloadFileCallback = OnStartDownloadFileFunction;

            //开启下载
            downloader.BeginDownload();
            yield return downloader;

            //检测下载结果
            if (downloader.Status == EOperationStatus.Succeed)
            {
                //下载成功
            }
            else
            {
                //下载失败
            }
        }


        /// <summary>
        /// 开始下载文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sizeBytes"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnStartDownloadFileFunction(string fileName, long sizeBytes)
        {
            UnityEngine.Debug.LogWarning($"fileName = {fileName} sizeBytes = {sizeBytes}");
        }

        /// <summary>
        /// 下载完成
        /// </summary>
        /// <param name="isSucceed"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnDownloadOverFunction(bool isSucceed)
        {
            UnityEngine.Debug.LogWarning($"isSucceed = {isSucceed}");
        }

        /// <summary>
        /// 更新中
        /// </summary>
        /// <param name="totalDownloadCount"></param>
        /// <param name="currentDownloadCount"></param>
        /// <param name="totalDownloadBytes"></param>
        /// <param name="currentDownloadBytes"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnDownloadProgressUpdateFunction(int totalDownloadCount, int currentDownloadCount, long totalDownloadBytes, long currentDownloadBytes)
        {
            UnityEngine.Debug.LogWarning("更新中");
        }

        /// <summary>
        /// 下载失败
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="error"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnDownloadErrorFunction(string fileName, string error)
        {
            UnityEngine.Debug.LogWarning("下载失败");
        }
        */
    }
}
