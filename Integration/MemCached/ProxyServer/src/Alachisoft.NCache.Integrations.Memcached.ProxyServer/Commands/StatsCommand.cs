// Copyright (c) 2017 Alachisoft
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Alachisoft.NCache.Integrations.Memcached.Provider;
using Alachisoft.NCache.Integrations.Memcached.ProxyServer.Common;

namespace Alachisoft.NCache.Integrations.Memcached.ProxyServer.Commands
{
    class StatsCommand : AbstractCommand
    {
        private string _argument;
        private Hashtable _stats;

        public Hashtable Stats
        {
            get { return _stats; }
            set { _stats = value; }
        }

        public StatsCommand()
            : base(Opcode.Stat)
        {
            _argument = null;
        }

        public StatsCommand(string argument)
            : base(Opcode.Stat)
        {
            _argument = argument;
        }

        public override void Execute(IMemcachedProvider cacheProvider)
        {
                _result = cacheProvider.GetStatistics(_argument);
        }
    }
}
