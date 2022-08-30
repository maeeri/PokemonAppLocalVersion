function FriendSearch() {
    document.getElementById("Friendsearch").InnerHTML =
        "@{ var Friends = DbController.SearchFriend('Mae'); foreach(var item in Friends) {@item.Username;}}";
}
