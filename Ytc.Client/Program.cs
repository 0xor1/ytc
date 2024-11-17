using Common.Client;
using Ytc.Api;
using Ytc.Client;
using Ytc.I18n;

await Client.Run<App, IApi>(args, S.Inst, (client) => new Api(client));
