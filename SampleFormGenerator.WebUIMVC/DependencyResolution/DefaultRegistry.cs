// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SampleFormGenerator.WebUIMVC.DependencyResolution {
    using SampleFormGenerator.BAL;
    using SampleFormGenerator.BAL.Contracts;
    using SampleFormGenerator.Model.Contracts;
    using SampleFormGenerator.Model.Entities;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            For<IConnection>().Use<DAL.Tools.SqlDbConnection>();

            For<IRepository<TblFormInfos>>().Use<DAL.Repositories.FormInfosRepository>();
            For<IRepository<TblFormData>>().Use<DAL.Repositories.FormDataRepository>();
            For<IRepository<TblFormInfoParameters>>().Use<DAL.Repositories.FormInfoParametersRepository>();
            For<IRepository<TblFormValues>>().Use<DAL.Repositories.FormValuesRepository>();
            For<IRepository<TblParameterTypes>>().Use<DAL.Repositories.ParameterTypesRepository>();

            For<DAL.Repositories.GeneralRepository>().Use<DAL.Repositories.GeneralRepository>();
            For<IFrom>().Use<Forms>();
        }

        #endregion
    }
}