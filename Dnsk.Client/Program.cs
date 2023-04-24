using Common.Client;
using Dnsk.Api;
using Dnsk.Client;
using Dnsk.I18n;

await Client.Run<App, IApi>(args, S.Inst, (client) => new Api(client));
