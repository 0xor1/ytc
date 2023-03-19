using Common.Client;
using Dnsk.Client;
using Dnsk.Client.Lib;
using Dnsk.I18n;
using Dnsk.Proto;

await Client.Run<App, Api.ApiClient, AuthService>(args, S.Inst, ci => new Api.ApiClient(ci));
