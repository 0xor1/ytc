using Common.Client;
using Dnsk.Client.Rz;
using Dnsk.Client.Rz.Lib;
using Dnsk.I18n;

await Client.Run<App, AuthService>(args, S.Inst);
