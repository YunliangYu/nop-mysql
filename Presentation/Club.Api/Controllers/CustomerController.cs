using Club.Core;
using Club.Core.Domain.Customers;
using Club.Core.Domain.Localization;
using Club.Core.Domain.Media;
using Club.Core.Domain.Security;
using Club.Services.Authentication;
using Club.Services.Common;
using Club.Services.Customers;
using Club.Services.Helpers;
using Club.Services.Localization;
using Club.Services.Logging;
using Club.Services.Media;
using Club.Services.Messages;
using Club.Web.Framework.Security.Captcha;
using System.Web.Http;
using System.Net.Http;
using System;
using Club.Core.Caching;
using System.Web;
using Club.Web.Framework.Controllers;
using System.IO;
using System.Threading.Tasks;
using Club.Web.Framework.Security;
using Club.Services.Security;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using Club.Web.Extensions;
using Club.Api.Models.Customers;

namespace Club.Web.Controllers
{
    public class CustomerController : BaseApiController
    {
        #region field
        private readonly IAuthenticationService _authenticationService;
        private readonly HttpContextBase _httpContext;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly DateTimeSettings _dateTimeSettings;
        private readonly ICacheManager _cacheManager;
        private readonly ILocalizationService _localizationService;
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly ICustomerService _customerService;
        private readonly ICustomerAttributeParser _customerAttributeParser;
        private readonly ICustomerAttributeService _customerAttributeService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly CustomerSettings _customerSettings;
        private readonly IPictureService _pictureService;
        private readonly IDownloadService _downloadService;
        private readonly IWebHelper _webHelper;
        private readonly ICustomerActivityService _customerActivityService;
        

        private readonly MediaSettings _mediaSettings;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly LocalizationSettings _localizationSettings;
        private readonly CaptchaSettings _captchaSettings;
        private readonly SecuritySettings _securitySettings;
        private readonly IEncryptionService _encryptionService;



        #endregion

        #region ctor
        public CustomerController(HttpContextBase httpContext, 
            IAuthenticationService authenticationService,
            IDateTimeHelper dateTimeHelper,
            DateTimeSettings dateTimeSettings, 
            ILocalizationService localizationService,
            IWorkContext workContext,
            IStoreContext storeContext,
            ICustomerService customerService,
            ICustomerAttributeParser customerAttributeParser,
            ICustomerAttributeService customerAttributeService,
            IGenericAttributeService genericAttributeService,
            ICustomerRegistrationService customerRegistrationService,
            CustomerSettings customerSettings,
            IPictureService pictureService, 
            IDownloadService downloadService,
            IWebHelper webHelper,
            ICustomerActivityService customerActivityService,
            MediaSettings mediaSettings,
            IWorkflowMessageService workflowMessageService,
            LocalizationSettings localizationSettings,
            CaptchaSettings captchaSettings,
            SecuritySettings securitySettings,
            IEncryptionService encryptionService,
            ICacheManager cacheManager)
        {
            this._httpContext = httpContext;
            this._authenticationService = authenticationService;
            this._dateTimeHelper = dateTimeHelper;
            this._dateTimeSettings = dateTimeSettings;
            this._localizationService = localizationService;
            this._workContext = workContext;
            this._storeContext = storeContext;
            this._customerService = customerService;
            this._customerSettings = customerSettings;
            this._customerAttributeParser = customerAttributeParser;
            this._customerAttributeService = customerAttributeService;
            this._genericAttributeService = genericAttributeService;
            this._customerRegistrationService = customerRegistrationService;
            this._pictureService = pictureService;
            this._downloadService = downloadService;
            this._webHelper = webHelper;
            this._customerActivityService = customerActivityService;
            this._mediaSettings = mediaSettings;
            this._workflowMessageService = workflowMessageService;
            this._localizationSettings = localizationSettings;
            this._captchaSettings = captchaSettings;
            this._securitySettings = securitySettings;
            this._encryptionService = encryptionService;
            this._cacheManager = cacheManager;
        }
        #endregion

        // GET api/<controller>
        /// <summary>
        /// 通过用户ID获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetCustomer")]
        public HttpResponseMessage GetCustomerById(int id)
        {
            try
            {
                if (!CheckTokenUser(id))
                    return ReturnResult(string.Empty, 1, "数据读取方式不合规");

                if (id == 0)
                {
                    return ReturnResult(string.Empty, 1, "不能提供空值参数");
                }
                var customer = _customerService.GetCustomerById(id);

                var result = new
                {
                    id = customer.Id,
                    username = customer.Username,
                    email = customer.Email.ConvertToString(),
                    firstname = customer.GetAttribute<string>(SystemCustomerAttributeNames.FirstName).ConvertToString(),
                    lastname = customer.GetAttribute<string>(SystemCustomerAttributeNames.LastName).ConvertToString(),
                    phone = customer.GetAttribute<string>(SystemCustomerAttributeNames.Phone).ConvertToString(),
                    imageurl = _pictureService.GetPictureUrl(customer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId), _mediaSettings.AvatarPictureSize, false).ConvertToString(),
                    actived = customer.Active
                    //notify = _customerDeviceService.GetCustomerDeviceByCustomerId(customer.Id) != null ? _customerDeviceService.GetCustomerDeviceByCustomerId(customer.Id).Notify : true
                };
                _customerActivityService.InsertActivity("PublicSite.Login", "App Login", customer);
                return ReturnResult(result, 0, string.Empty);
            }
            catch (Exception ex)
            {
                LogException(ex);
                return ReturnResult(string.Empty, 1, "读取数据出现错误");
            }
           
        }

        // GET api/<controller>/5
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetCaptcha")]
        [AllowAnonymous]
        public HttpResponseMessage GetCaptcha(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
            {
                return ReturnResult(string.Empty, 1, "不能传入空的参数值");
            }
            try
            {
                Random rd = new Random();
                int num = rd.Next(100000, 1000000);
                MemoryCacheManager m = new MemoryCacheManager();
                m.Set("86" + mobile, num, 1);
                //_sendNoticeService.SendSMS(mobile, num.ToString());
                return ReturnResult("验证已发送到您的手机上 " + num.ToString(), 0, string.Empty);
            }
            catch (Exception ex)
            {
                LogException(ex);
                return ReturnResult(string.Empty, 1, "生成验证码失败");
            }
        }

        // POST api/<controller>
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="registtype"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="captcha"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("MobileRegist")]
        [AllowAnonymous]
        public HttpResponseMessage PostRegistCustomerByMobile(MobileRegist regist)
        {
            if (regist == null)
                return ReturnResult(string.Empty, 1, "不能传入空的参数值");
            if (string.IsNullOrWhiteSpace(regist.Mobile) || string.IsNullOrWhiteSpace(regist.Password))
            {
                return ReturnResult(string.Empty, 1, "不能传入空的参数值");
            }
            if (regist.Captcha == 0)
            {
                return ReturnResult(string.Empty, 1, "验证码不能为空");
            }
            try
            {
                var customer = _workContext.CurrentCustomer;

                var registrationRequest = new CustomerRegistrationRequest(customer, string.Empty, regist.Mobile, regist.Password, _customerSettings.DefaultPasswordFormat,_storeContext.CurrentStore.Id, true);
                MemoryCacheManager m = new MemoryCacheManager();
                var smsCaptcha = 0;
                if (m.Get<int>(regist.Mobile) > 0)
                {
                    smsCaptcha = m.Get<int>(regist.Mobile);
                }
                else
                {
                    return ReturnResult(string.Empty, 1, "验证码已经失效请重新获取");
                }
                if (regist.Captcha != smsCaptcha)
                {
                    return ReturnResult(string.Empty, 1, "验证码错误，请重新输入");
                }
                var registrationResult = _customerRegistrationService.RegisterCustomer(registrationRequest);
                if (registrationResult.Success)
                {
                    var customerNew = _customerService.GetCustomerByUsername(regist.Mobile);
                    _authenticationService.SignIn(customerNew, true);
                    var result = new
                    {
                        token = customer.CustomerGuid,
                        id = customerNew.Id,
                        username = customerNew.Username,
                        email = customerNew.Email.ConvertToString(),
                        firstname = customerNew.GetAttribute<string>(SystemCustomerAttributeNames.FirstName).ConvertToString(),
                        lastname = customerNew.GetAttribute<string>(SystemCustomerAttributeNames.LastName).ConvertToString(),
                        gender = customerNew.GetAttribute<string>(SystemCustomerAttributeNames.Gender).ConvertToString(),
                        birthday = customerNew.GetAttribute<DateTime?>(SystemCustomerAttributeNames.DateOfBirth).ToString().ConvertToString(),
                        imageurl = _pictureService.GetPictureUrl(
                                  customerNew.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId),
                                  _mediaSettings.AvatarPictureSize,
                                  false).ConvertToString()
                    };
                    return ReturnResult(result, 0, "注册成功");
                }
                else
                {
                    return ReturnResult(string.Empty, 1, registrationResult.Errors[0]);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return ReturnResult(string.Empty, 1, "读取数据出现错误");
            }
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="gender"></param>
        /// <param name="birthday"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Update")]
        public HttpResponseMessage PostUpdateCustomer(CustomerModel customer)
        {
            if (!CheckTokenUser(customer.Id))
                return ReturnResult(string.Empty, 1, "数据读取方式不合规");

            if (customer == null)
                return ReturnResult(string.Empty, 1, "不能传入空的数据");
            if (string.IsNullOrWhiteSpace(customer.Username))
            {
                return ReturnResult(string.Empty, 1, "手机号不能为空");
            }

            try
            {
                var oldCustomer = _customerService.GetCustomerById(customer.Id);
                //form fields
                //username 
                if (_customerSettings.UsernamesEnabled && this._customerSettings.AllowUsersToChangeUsernames)
                {
                    if (!oldCustomer.Username.Equals(customer.Username.Trim(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        //change username
                        _customerRegistrationService.SetUsername(oldCustomer, customer.Username.Trim());
                    }
                }


         
                _genericAttributeService.SaveAttribute(oldCustomer, SystemCustomerAttributeNames.FirstName, customer.FirstName);
                _genericAttributeService.SaveAttribute(oldCustomer, SystemCustomerAttributeNames.LastName, customer.LastName);

                var result = new
                {
                    id = oldCustomer.Id,
                    username = oldCustomer.Username,
                    email = oldCustomer.Email.ConvertToString(),
                    firstname = oldCustomer.GetAttribute<string>(SystemCustomerAttributeNames.FirstName).ConvertToString(),
                    lastname = oldCustomer.GetAttribute<string>(SystemCustomerAttributeNames.LastName).ConvertToString(),
                    imageurl = _pictureService.GetPictureUrl(
                              oldCustomer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId),
                              _mediaSettings.AvatarPictureSize,
                              false).ConvertToString()
                };
                return ReturnResult(result, 0, string.Empty);
            }
            catch (Exception ex)
            {
                LogException(ex);
                return ReturnResult(string.Empty, 1, ex.Message);
            }
        }

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("UploadAvatar")]
        public async Task<HttpResponseMessage> PostUploadAvatar()
        {
           
            try
            {
                //var streamProvider = new MultipartMemoryStreamProvider();
                string root = HttpContext.Current.Server.MapPath("~");
                string tmpRoot = root + "/App_Data/image";
                var provider = new MultipartFormDataStreamProvider(tmpRoot);
                
                Request.Content.Headers.ContentType.CharSet = "UTF-8";

                await Request.Content.ReadAsMultipartAsync(provider);
                var customerid = provider.FormData.GetValues("id")[0];
                if (string.IsNullOrWhiteSpace(customerid))
                    return ReturnResult(string.Empty, 1, "上传头像发生错误，请重新上传");

                if (!CheckTokenUser(Convert.ToInt32(customerid)))
                    return ReturnResult(string.Empty, 1, "数据读取方式不合规");

                var customer = _customerService.GetCustomerById(Convert.ToInt32(customerid));
                var customerAvatar = _pictureService.GetPictureById(customer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId));
                var newCustomerAvatar = new Picture();
                var uploadFile = provider.FileData[0];
                var contentType = uploadFile.Headers.ContentType.ToString();
                //LogException(new Exception(contentType));
                if ((uploadFile != null) && (!String.IsNullOrEmpty(uploadFile.LocalFileName)))
                {
                    int avatarMaxSize = _customerSettings.AvatarMaximumSizeBytes;
                    FileInfo fileinfo = new FileInfo(uploadFile.LocalFileName);
                    if (fileinfo.Length > avatarMaxSize)
                        throw new SiteException(string.Format(_localizationService.GetResource("Account.Avatar.MaximumUploadedFileSize"), avatarMaxSize));

                    FileStream fileS = fileinfo.Open(FileMode.Open);
                    long size = fileinfo.Length; 
                    var img = new byte[size];
                    fileS.Read(img, 0, Convert.ToInt32(size));

                    byte[] customerPictureBinary = img;
                    if (customerAvatar != null)
                    {
                        _pictureService.DeletePicture(customerAvatar);
                        newCustomerAvatar = _pictureService.InsertPicture(customerPictureBinary, contentType, null);
                        //LogException(new Exception("UploadAvatar delete:"));
                    }
                    else
                    {
                        newCustomerAvatar = _pictureService.InsertPicture(customerPictureBinary, contentType, null);
                        //LogException(new Exception("UploadAvatar insert:" + newCustomerAvatar.Id));
                    }
                       
                    //fileinfo.Delete();
                }
                int customerAvatarId = 0;
                if (newCustomerAvatar != null)
                    customerAvatarId = newCustomerAvatar.Id;
                //LogException(new Exception("UploadAvatar newCustomerAvatar:" + customerAvatarId));
                _genericAttributeService.SaveAttribute(customer, SystemCustomerAttributeNames.AvatarPictureId, customerAvatarId);
                var result = new
                {
                    avatarurl = _pictureService.GetPictureUrl(customer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId),_mediaSettings.AvatarPictureSize, false)
                };
                //LogException(new Exception("UploadAvatar url:" + _pictureService.GetPictureUrl(customer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId), _mediaSettings.AvatarPictureSize, false)));
                return ReturnResult(result, 0, string.Empty);
            }
            catch (Exception ex)
            {
                LogException(ex);
                return ReturnResult(string.Empty, 1, "上传头像发生错误，请重新上传");
            }
           
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="usename"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Login")]
        [AllowAnonymous]
        public HttpResponseMessage PostLogin(CustomerLoginModel value)
        {
            if (string.IsNullOrWhiteSpace(value.UserName) || string.IsNullOrWhiteSpace(value.Password))
            {
                return ReturnResult(string.Empty, 1, "不能传入空的参数值");
            }

            try
            {
                var checkResult = ValidateSignature(value.Signature, value.timestamp, value.Nonce, value.AppCode);

                if (!checkResult)
                    return ReturnResult(string.Empty, 1, "不合法的登录方式，您的IP将会被限制访问"); 
                var loginResult = _customerRegistrationService.ValidateCustomer(value.UserName, value.Password);
                var errorMessge = string.Empty;
                Customer customer = new Customer();
                switch (loginResult)
                {
                    case CustomerLoginResults.Successful:
                        {
                            //if (customer == null){
                            customer = _customerService.GetCustomerByUsername(value.UserName);
                            //}
                            //sign in new customer
                            _authenticationService.SignIn(customer, true);
                        }
                        break;
                    case CustomerLoginResults.CustomerNotExist:
                        errorMessge = _localizationService.GetResource("Account.Login.WrongCredentials.CustomerNotExist");
                        break;
                    case CustomerLoginResults.Deleted:
                        errorMessge = _localizationService.GetResource("Account.Login.WrongCredentials.Deleted");
                        break;
                    case CustomerLoginResults.NotActive:
                        errorMessge = _localizationService.GetResource("Account.Login.WrongCredentials.NotActive");
                        break;
                    case CustomerLoginResults.NotRegistered:
                        errorMessge = _localizationService.GetResource("Account.Login.WrongCredentials.NotRegistered");
                        break;
                    case CustomerLoginResults.WrongPassword:
                    default:
                        errorMessge = _localizationService.GetResource("Account.Login.WrongCredentials");
                        break;
                }
                if (!string.IsNullOrWhiteSpace(errorMessge))
                {
                    return ReturnResult(string.Empty, 1, errorMessge);
                }
                else
                {
                    var result = new
                    {
                        token = WebApiValidate.GetApiValidateToken(customer.Id),
                        id = customer.Id,
                        username = customer.Username,
                        email = customer.Email.ConvertToString(),
                        firstname = customer.GetAttribute<string>(SystemCustomerAttributeNames.FirstName).ConvertToString(),
                        lastname = customer.GetAttribute<string>(SystemCustomerAttributeNames.LastName).ConvertToString(),
                        imageurl = _pictureService.GetPictureUrl(
                        customer.GetAttribute<int>(SystemCustomerAttributeNames.AvatarPictureId),
                        _mediaSettings.AvatarPictureSize,
                        false).ConvertToString()
                    };

                    return ReturnResult(result, 0, string.Empty);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return ReturnResult(string.Empty, 1, "读取数据出现错误");
            }
        }

        /// <summary>
        /// 忘记密码功能
        /// </summary>
        /// <param name="registtype"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("PasswordRecovery")]
        [AllowAnonymous]
        public HttpResponseMessage PostPasswordRecoverySend(PasswordRecoveryModel value)
        {
            if (string.IsNullOrWhiteSpace(value.UserName))
            {
                return ReturnResult(string.Empty, 1, "不能传入空的参数值");
            }
            try
            {
                var ResultStatus = 0;
                var ErrorMessage = string.Empty;
                var customer = _customerService.GetCustomerByUsername(value.UserName);
                    if (customer != null && customer.Active && !customer.Deleted)
                    {
                        Random rd = new Random();
                        int newPassword = rd.Next(100000, 1000000);
                        //save token and current date
                        var changePasswordResult = _customerRegistrationService.ResetPassword(_customerSettings.DefaultPasswordFormat, value.UserName, newPassword.ToString());
                        if (changePasswordResult.Success)
                        {
                            //send SMS
                            //_sendNoticeService.SendNewPassword(customer.Mobile, newPassword.ToString());
                            //_workflowMessageService.SendCustomerPasswordRecoveryMessage(customer, _workContext.WorkingLanguage.Id, newPassword.ToString());
                            ResultStatus = 0;
                            ErrorMessage = _localizationService.GetResource("Account.PasswordRecovery.SMSHasBeenSent");
                        }
                    }
                    else
                    {
                        ResultStatus = 1;
                        ErrorMessage = _localizationService.GetResource("Account.PasswordRecovery.MobileNotFound");
                    }

                    return ReturnResult(string.Empty, ResultStatus, ErrorMessage);
             
            }
            catch (Exception ex)
            {
                LogException(ex);
                return ReturnResult(string.Empty, 1, "读取数据出现错误");
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ChangePassword")]
        public HttpResponseMessage PostChangePassword(ChangePasswordModel value)
        {
            if (!CheckTokenUser(value.id))
                return ReturnResult(string.Empty, 1, "数据读取方式不合规");

            if (string.IsNullOrWhiteSpace(value.OldPassword) || string.IsNullOrWhiteSpace(value.NewPassword))
            {
                return ReturnResult(string.Empty, 1, "不能传入空的参数值");
            }


            try
            {
                var customer = _customerService.GetCustomerById(value.id);

                if (customer != null && customer.Active && !customer.Deleted)
                {
                    var ResultStatus = 0;
                    var ErrorMessage = string.Empty;
                    var changePasswordRequest = new ChangePasswordRequest(customer.Username,
                        true, _customerSettings.DefaultPasswordFormat, value.NewPassword, value.OldPassword);
                    var changePasswordResult = _customerRegistrationService.ChangePassword(changePasswordRequest);
                    if (changePasswordResult.Success)
                    {
                        ResultStatus = 0;
                        ErrorMessage = _localizationService.GetResource("Account.ChangePassword.Success");
                        return ReturnResult(string.Empty, ResultStatus, ErrorMessage);
                    }
                    ResultStatus = 1;
                    ErrorMessage = changePasswordResult.Errors[0];
                    //If we got this far, something failed, redisplay form
                    return ReturnResult(string.Empty, ResultStatus, ErrorMessage);
                }
                else
                {
                    return ReturnResult(string.Empty, 1, "未找到相应用户");
                }

            }
            catch (Exception ex)
            {
                LogException(ex);
                return ReturnResult(string.Empty, 1, "读取数据出现错误");
            }
        }

        ///<summary>
        /// 检查应用接入的数据完整性
        /// </summary>
        /// <param name="signature">加密签名内容</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">随机字符串</param>
        /// <param name="appid">应用接入Id</param>
        /// <returns></returns>
        protected bool ValidateSignature(string signature, string timestamp, string nonce, string appid)
        {
            string[] ArrTmp = { "club", _securitySettings.EncryptionKey, timestamp, nonce, appid };
            Array.Sort(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = _encryptionService.CreateHash(Encoding.UTF8.GetBytes(tmpStr), "SHA1");
            tmpStr = tmpStr.ToLower();
            long timestampInt;
            if (tmpStr == signature && long.TryParse(timestamp, out timestampInt))
            {
                return true;
            }
            else
            { 
                return false; 
            }
        }
    }
}