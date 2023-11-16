using Common.Server;
using Dnsk.Db;
using Dnsk.Eps;
using Dnsk.I18n;

Server.Run<DnskDb, Dnsk.Client.Host>(args, S.Inst, DnskEps.Eps);
