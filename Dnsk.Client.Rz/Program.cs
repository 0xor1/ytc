using Common.Client;
using Dnsk.Client.Rz;
using Dnsk.Client.Rz.Lib;
using Dnsk.I18n;
using Dnsk.Proto;

await Client.Run<App, Api.ApiClient, AuthService>(args, S.Inst, ci => new Api.ApiClient(ci));
