import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from '../services/AxiosService'

class KeepsService {
  async getKeeps() {
    try {
      const res = await api.get('api/keeps')
      AppState.keeps = res.data
      logger.log(res.data)
    } catch (error) {
      logger.error(error)
    }
  }

  async getKeepsById(profileId) {
    try {
      const res = await api.get('api/profiles/' + profileId + '/keeps')
      AppState.keeps = res.data
      logger.log(res.data)
    } catch (error) {
      logger.error(error)
    }
  }

  async createKeep(newKeep) {
    try {
      const res = await api.post('api/keeps', newKeep)
      AppState.keeps = res.data
      this.getKeeps()
    } catch (error) {
      logger.error(error)
    }
  }

  async editViews(id) {
    try {
      await api.put('api/keeps/' + id + '?views=1')
      this.getKeeps()
    } catch (error) {
      logger.error(error)
    }
  }

  async editKeepCount(id) {
    try {
      await api.put('api/keeps/' + id + '/keepcount?keeps=1')
      this.getKeeps()
    } catch (error) {
      logger.error(error)
    }
  }

  async deleteKeeps(id) {
    try {
      await api.delete('api/keeps/' + id)
      this.getKeeps()
    } catch (error) {
      logger.error(error)
    }
  }
}
export const keepsService = new KeepsService()
