using System;
using System.Configuration;
using System.Runtime.CompilerServices;


namespace Atk.WebCore.Infrastructure
{
    /// <summary>
    /// Provides access to the singleton instance of the Fni engine.
    /// </summary>
    public class EngineContext
    {
        #region Utilities



        #endregion

        #region Methods

        /// <summary>
        /// Initializes a static instance of the Fni factory.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Create()
        {
            //create NopEngine as engine
            return Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new AtkEngine());
        }


        #endregion

        #region Properties

        /// <summary>
        /// Gets the singleton Fni engine used to access Fni services.
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Create();
                }
                return Singleton<IEngine>.Instance;
            }
        }




        #endregion
    }
}
