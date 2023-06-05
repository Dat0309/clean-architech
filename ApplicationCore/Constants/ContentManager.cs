using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Constants
{
    /// <summary>
    /// This is class that serves as a  content manager storing a hard-coded string in this project.
    /// </summary>
    public static class ContentManager
    {

        public const string ContentType = "application/json";
        public const string ApiKey = "ApiKey";
        public const string AllowedApiKeys = "AllowedApiKeys";
        public const string PageSize = "PageSize";
        public const string PageNumber = "PageNumber";

        /// <summary>
        /// Content Exception
        /// </summary>
        public const string RouterNotFound = "Router not found";
        public const string InvalidToken = "Invalid Token";
        public const string InternalServerError = "Internal server error!";
        public const string RequiredApi = "API Key is required to proceed this request.";
        public const string UnauthorizedWarning = "Unauthorized client, your API Key is not matched.";
        public const string NullTableExceptionMsg = "resource is no longer found at a specific URL and will not return (it will permanently not be found)";
        public const string InvalidModelStateMsg = "The server refuses to accept the request without a defined Content- Length. The client MAY repeat the request if it adds a valid Content-Length header field.";
        public const string InvalidMsg = "The client has indicated preconditions in its headers which the server does not meet.";
        public const string RecordNotFoundMsg = "Request entity is larger than limits defined By server.";

        public const string NotFoundContactByIDMsg = "Contact not found with ID ";
        public const string NotFoundSliderByIDMsg = "Slider not found with ID ";
        public const string NotFoundSliderByTypeIDMsg = "Slider not found with Type ID";
        public const string NotFoundSliderTypeByIDMsg = "Slider Type not found with ID ";
        public const string NotFoundPostByIDMsg = "Post not found with ID ";
        public const string NotFoundPostByTypeID = "Post not found with Type ID ";
        public const string NotFoundPostTypeIDMsg = "Post Type not found with ID ";
        public const string IDNotMatch = "ID in URL does not match ID in request body.";
        public const string CantGetEntities = "Can't Get this entities with an exception";
        public const string NotFoundEntitiesWithID = "Not found entities with ID ";

        /// <summary>
        /// Response content
        /// </summary>
        public const string SuccessGetAllContacts= "Succeeded to Get All Contacts";
        public const string SuccessGetContactByID = "Suceeded to Get Contact By id";
        public const string SuccessCreateContact = "Succeeded to Create Contact";
        public const string FailUpdateContact = "Fail to Update Contact";
        public const string FailCreateContact = "Fail to Create Contact";
        public const string SuccessUpdateContact = "Update Contact Successfull";
        public const string SuccessDeleteContact = "Success to Delete Contact";

        public const string SuccessGetAllPost = "Succeeded to Get All Posts";
        public const string SuccessGetPostPagination = "Success to Get Posts with Pagination";
        public const string SuccessGetPostByID = "Suceeded to Get Post By id";
        public const string SuccessGetPostByTypeID = "Success to Get Post By Type id: ";
        public const string SuccessCreatePost = "Succeeded to Create Post";
        public const string FailUpdatePost = "Fail to Update Post";
        public const string SuccessUpdatePost = "Update Post Successfull";
        public const string SuccessDeletePost = "Success to Delete Post";

        public const string SuccessGetAllPostType = "Succeeded to Get All Posts Type";
        public const string SuccessGetPostTypeByID = "Suceeded to Get Post Type By id";
        public const string SuccessCreatePostType = "Succeeded to Create Post Type";
        public const string FailUpdatePostType = "Fail to Update Post Type";
        public const string SuccessUpdatePostType = "Update Post Type Successfull";
        public const string SuccessDeletePostType = "Success to Delete Post Type";

        public const string SuccessGetAllSlider = "Succeeded to Get All Sliders";
        public const string SuccessGetSliderPagination = "Success to Get Sliders with Pagination";
        public const string SuccessGetSliderByID = "Suceeded to Get Slider By id";
        public const string SuccessGetSliderByTypeID = "Succeeded toGet Slider By Type id";
        public const string SuccessCreateSlider = "Succeeded to Create Slider";
        public const string FailUpdateSlider = "Fail to Update Slider ";
        public const string SuccessUpdateSlider = "Update Slider Successfull";
        public const string SuccessDeleteSlider = "Success to Delete Slider";

        public const string SuccessGetAllSliderType = "Succeeded to Get All Sliders Type";
        public const string SuccessGetSliderTypeByID = "Suceeded to Get Slider Type By id";
        public const string SuccessCreateSliderType = "Succeeded to Create Slider Type";
        public const string FailUpdateSliderType = "Fail to Update Slider Type";
        public const string SuccessUpdateSliderType = "Update Slider Type Successfull";
        public const string SuccessDeleteSliderType = "Success to Delete Slider Type";

        /// <summary>
        /// Logging content
        /// </summary>
        public const string LogGetAllContactTable = "Getting All contract Table..";
        public const string LogGetContactByID = "Getting a Contact record By Id..";
        public const string LogCreateContact = "Creating a new Contact executing..";
        public const string LogUpdateContact = "Updating Contact..";
        public const string LogDeleteContact = "Deleting a Contact record..";

        public const string LogGetAllPostTable = "Getting All Post Table..";
        public const string LogGetPostByTypeID = "Get Post By TypeId executing...";
        public const string LogGetPostPagination = "Get Post By Type support Pagination executing...";
        public const string LogGetPostByID = "Getting a Post record By Id..";
        public const string LogCreatePost = "Creating a new Post executing..";
        public const string LogUpdatePost = "Updating Post..";
        public const string LogDeletePost = "Deleting a Post record..";

        public const string LogGetAllPostTypeTable = "Getting All Post Type Table..";
        public const string LogGetPostTypeByID = "Getting a Post Type record By Id..";
        public const string LogCreatePostType = "Creating a new Post Type executing..";
        public const string LogUpdatePostType = "Updating Post Type..";
        public const string LogDeletePostType = "Deleting a Post Type record..";

        public const string LogGetAllSliderTable = "Getting All Sliders Table..";
        public const string LogGetSliderByTypeID = "Get Slider By TypeId executing...";
        public const string LogGetSliderPagination = "Get Slider By Type support Pagination executing...";
        public const string LogGetSliderByID = "Getting a Slider record By Id..";
        public const string LogCreateSlider = "Creating a new Slider executing..";
        public const string LogUpdateSlider = "Updating Slider..";
        public const string LogDeleteSlider = "Deleting a Slider record..";

        public const string LogGetAllSliderTypeTable = "Getting All Slider Type Table..";
        public const string LogGetSliderTypeByID = "Getting a Slider Type record By Id..";
        public const string LogCreateSliderType = "Creating a new Slider Type executing..";
        public const string LogUpdateSliderType = "Updating Slider Type..";
        public const string LogDeleteSliderType = "Deleting a Slider Type record..";

        public const int DefaultPageSize = 10;
        public const int DefaultPageNumber = 1;

        // Validation data
        public const int ValidationNameLength = 100;
        public const int ValidationSubjectLength = 150;
        public const int ValidationDescLength = 500;
        public const int ValidationEmailLength = 100;
        public const int ValidationPhoneLength = 50;

        public const string ValidationNameMSG = "Contact Name cannot longer than 100";
        public const string ValidationSubjectMSG = "Contact Subject cannot longer than 150";
        public const string ValidationDescMSG = "Contact Description cannot longer than 500";
        public const string ValidationEmailMSG = "Contact Email cannot longer than 100";
        public const string ValidationPhoneMSG = "Contact Phone nummber cannot longer than 50";
    }
}
