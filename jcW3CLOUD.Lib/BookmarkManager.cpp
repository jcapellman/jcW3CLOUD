#include "BookmarkManager.h"

BookmarkManager::BookmarkManager(string fileName) {
	
}

BookmarkManager::BookmarkManager() {

}

bool BookmarkManager::AddBookmark(string description, string url) {
	BookmarkItem item = BookmarkItem(description, url);

	this->_bookmarks->insert(item);

	return true;
}

bool BookmarkManager::RemoveBook(int id) {
	BookmarkItem item = this->_bookmarks.at(id);

	if (item == NULL) {
		return false;
	}

	return true;
}

vector<BookmarkItem> BookmarkManager::GetAll() {
	return this->_bookmarks;
}
