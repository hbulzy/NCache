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
using System.Text;

using Alachisoft.NCache.Web.Caching;
using System.IO;
using Alachisoft.NCache.Web.Communication;
using Alachisoft.NCache.Common.Protobuf.Util;
using Alachisoft.NCache.Web.Caching.Util;
using Alachisoft.NCache.Runtime.Events;

namespace Alachisoft.NCache.Web.Command
{
    class RegisterKeyNotificationCommand : CommandBase
    {
        Alachisoft.NCache.Common.Protobuf.RegisterKeyNotifCommand _registerKeyNotifCommand;
        short _updateCallbackId;
        short _removeCallabackId;
       

        public RegisterKeyNotificationCommand(string key, short updateCallbackid, short removeCallbackid,bool notifyOnItemExpiration)
        {
            base.name = "RegisterKeyNotificationCommand";
            base.key = key;

            _registerKeyNotifCommand = new Alachisoft.NCache.Common.Protobuf.RegisterKeyNotifCommand();
            _registerKeyNotifCommand.key = key;

            _registerKeyNotifCommand.removeCallbackId = removeCallbackid;
            _registerKeyNotifCommand.updateCallbackId = updateCallbackid; 
            _registerKeyNotifCommand.notifyOnExpiration = notifyOnItemExpiration;

            _registerKeyNotifCommand.requestId = base.RequestId;
        }

        public RegisterKeyNotificationCommand(string key, short update, short remove, EventDataFilter dataFilter, bool notifyOnItemExpiration)
            :this(key,update,remove,notifyOnItemExpiration)
        {
            _registerKeyNotifCommand.datafilter = (int)dataFilter;
        }


        internal override CommandType CommandType
        {
            get { return CommandType.REGISTER_KEY_NOTIF; }
        }

        internal override RequestType CommandRequestType
        {
            get { return RequestType.AtomicWrite; }
        }

        protected override void CreateCommand()
        {
            base._command = new Alachisoft.NCache.Common.Protobuf.Command();
            base._command.requestID = base.RequestId;
            base._command.registerKeyNotifCommand = _registerKeyNotifCommand;
            base._command.type = Alachisoft.NCache.Common.Protobuf.Command.Type.REGISTER_KEY_NOTIF;

        }
    }
}
